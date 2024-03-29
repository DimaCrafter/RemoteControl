﻿using Common;
using RCClient.Properties;
using RCClient.UI.ExecuteProps;
using RCClient.UI.Modals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCClient.UI.Forms {
    public partial class ScriptForm : Form {
        private ExecScript tmp;
        private TaskCompletionSource<ExecScript> taskSource;
        public ScriptForm (bool isTmp = false) {
            InitializeComponent();
            Icon = Icon.FromHandle(Resources.script32.GetHicon());

            stepsList.SmallImageList = new ImageList {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(16, 16)
            };

            if (isTmp) {
                tmp = new ExecScript { name = "[Одноразовый сценарий]" };
                scriptList.Items.Add(tmp.name);
                scriptList.SelectedIndex = 0;

                createScriptBtn.Enabled = false;
                renameScriptBtn.Enabled = false;
                removeScriptBtn.Enabled = false;
            }

            for (var i = 0; i < stepTypes.Length; i++) {
                stepTypes[i].index = i;
            }
        }

        private Executable[] stepTypes = new Executable[] {
            new RunProgram(),
            new SystemAction(),
            new CloseProgram(),
            new WaitDevice(),
            new SyncTime(),
            new Copy(),
            new Move(),
            new Remove(),
            new WindowsMaintenance()
        };

        private ExecScript currentScript {
            get {
                if (scriptList.SelectedIndex == -1) return null;
                else if (tmp != null) return tmp;
                else return Settings.data.scripts[scriptList.SelectedIndex];
            }
        }

        private void onLoad (object sender, EventArgs e) {
            if (tmp == null) {
                foreach (var script in Settings.data.scripts) {
                    scriptList.Items.Add(script.name);
                }
            }

            foreach (var type in stepTypes) {
                stepTypeBox.Items.Add(type.name);
            }

            onScriptSelect();
        }

        private async void CreateScript (object sender, EventArgs e) {
            var res = await TextPrompt.Open(this, "Создание сценария", "Введите название для нового сценария:");
            if (res.success) {
                Settings.data.scripts.Add(new ExecScript {
                    name = res.value
                });

                scriptList.Items.Add(res.value);
                scriptList.SelectedIndex = scriptList.Items.Count - 1;
            }
        }

        private void RemoveScript (object sender, EventArgs e) {
            if (scriptList.SelectedIndex != -1) {
                if (MessageBox.Show($"Вы точно хотите удалить сценарий {currentScript.name}?", "Удаление сценария", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;
                }

                Settings.data.scripts.RemoveAt(scriptList.SelectedIndex);
                scriptList.Items.RemoveAt(scriptList.SelectedIndex);
            }
        }

        private async void RenameScript (object sender, EventArgs e) {
            var res = await TextPrompt.Open(this, "Изменение сценария", "Введите новое название сценария:", (string) scriptList.SelectedItem);
            if (res.success) {
                scriptList.Items[scriptList.SelectedIndex] = res.value;
                currentScript.name = res.value;
            }
        }

        private void onScriptSelect (object sender = null, EventArgs e = null) {
            stepsList.SelectedItems.Clear();
            stepsList.Items.Clear();
            stepTypeBox.SelectedIndex = -1;

            if (scriptList.SelectedIndex == -1) {
                stepsList.Enabled = false;
                addStepBtn.Enabled = false;
                removeStepBtn.Enabled = false;
                stepUpBtn.Enabled = false;
                stepDownBtn.Enabled = false;
            } else {
                stepsList.Enabled = true;
                addStepBtn.Enabled = true;
                removeStepBtn.Enabled = true;
                stepUpBtn.Enabled = true;
                stepDownBtn.Enabled = true;

                stepsList.BeginUpdate();
                foreach (var stepInfo in currentScript.steps) {
                    var stepType = GetStepType(stepInfo["type"]);
                    stepsList.SmallImageList.Images.Add(stepType.icon);
                    stepsList.Items.Add(new ListViewItem(stepType.name, stepsList.SmallImageList.Images.Count - 1));
                }
                stepsList.EndUpdate();
            }

        }

        private void AddStep (object sender, EventArgs e) {
            var step = stepTypes[0];
            step.result = new Dictionary<string, string>();
            step.result["type"] = step.type;
            step.Reset();
            currentScript.steps.Add(step.result);

            stepsList.BeginUpdate();
            stepsList.SmallImageList.Images.Add(step.icon);
            stepsList.Items.Add(new ListViewItem(step.name, stepsList.SmallImageList.Images.Count - 1));
            stepsList.SelectedIndices.Clear();
            stepsList.SelectedIndices.Add(stepsList.Items.Count - 1);
            stepsList.EndUpdate();
        }

        private void onStepSelect (object sender = null, EventArgs e = null) {
            propsPanel.Controls.Clear();

            if (stepsList.SelectedItems.Count == 0) {
                stepTypeBox.Enabled = false;
                    stepTypeBox.SelectedIndex = -1;
            } else {
                stepTypeBox.Enabled = true;
                stepTypeBox.SelectedIndex = GetStepType(currentScript.steps[stepsList.SelectedIndices[0]]["type"]).index;

                onStepTypeChanged(sender, e);
            }
        }

        private Executable GetStepType (string typeName) {
            foreach (var stepType in stepTypes) {
                if (stepType.type == typeName)
                    return stepType;
            }

            return null;
        }

        private void onStepTypeChanged (object sender, EventArgs e) {
            if (stepTypeBox.SelectedIndex == -1) return;
            var step = stepTypes[stepTypeBox.SelectedIndex];

            propsPanel.Controls.Clear();
            propsPanel.Controls.Add(step);
            step.result = currentScript.steps[stepsList.SelectedIndices[0]];
            step.result["type"] = step.type;
            step.LoadResult();

            stepsList.SelectedItems[0].Text = step.name;
            stepsList.SmallImageList.Images[stepsList.SelectedIndices[0]] = step.icon;
        }

        private void MoveListItem (IList list, int index, int offset) {
            var item = list[index];
            list.RemoveAt(index);
            list.Insert(index + offset, item);
        }

        private void StepUp (object sender, EventArgs e) {
            if (stepsList.SelectedItems.Count == 0) return;

            var index = stepsList.SelectedIndices[0];
            if (index == 0) return;

            MoveListItem(currentScript.steps, index, -1);
            MoveListItem(stepsList.Items, index, -1);

            stepsList.SelectedIndices.Remove(0);
            stepsList.SelectedIndices.Add(index - 1);
        }

        private void StepDown (object sender, EventArgs e) {
            if (stepsList.SelectedItems.Count == 0) return;

            var index = stepsList.SelectedIndices[0];
            if (index == stepsList.Items.Count - 1) return;

            MoveListItem(currentScript.steps, index, 1);
            MoveListItem(stepsList.Items, index, 1);

            stepsList.SelectedIndices.Remove(0);
            stepsList.SelectedIndices.Add(index + 1);
        }

        public static Task<ExecScript> CreateTempScript () {
            var form = new ScriptForm(true) {
                taskSource = new TaskCompletionSource<ExecScript>()
            };

            form.Show();
            return form.taskSource.Task;
        }

        private void ScriptForm_FormClosing (object sender, FormClosingEventArgs e) {
            if (tmp != null) {
                taskSource.SetResult(tmp);
                return;
            }

            switch (MessageBox.Show("Сохранить внесённые изменения?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
                case DialogResult.Yes:
                    Settings.Save();
                    break;
                case DialogResult.No:
                    Settings.LoadInit();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void removeStepBtn_Click (object sender, EventArgs e) {
            var index = stepsList.SelectedIndices[0];
            stepsList.Items.RemoveAt(index);
            currentScript.steps.RemoveAt(index);

            if (index == 0) {
                if (stepsList.Items.Count != 0) stepsList.SelectedIndices.Add(0);
            } else {
                stepsList.SelectedIndices.Add(index - 1);
            }
        }

        private void Export (object sender, EventArgs e) {
            saveDialog.FileName = currentScript.name;
            if (saveDialog.ShowDialog(this) == DialogResult.OK) {
                var stream = saveDialog.OpenFile();
                currentScript.Serialize(stream);
                stream.Close();
            }
        }

        private void Import (object sender, EventArgs e) {
            if (openDialog.ShowDialog(this) == DialogResult.OK) {
                var stream = openDialog.OpenFile();
                var script = ExecScript.Deserialize(stream);
                stream.Close();

                Settings.data.scripts.Add(script);
                scriptList.Items.Add(script.name);
                scriptList.SelectedIndex = scriptList.Items.Count - 1;
            }
        }
    }
}
