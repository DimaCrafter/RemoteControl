using System;

namespace RCClient {
    class Utils {
        public class PareseIntError : Exception {
            public PareseIntError (string message): base(message) {
            }
        }
        public static int ParseInt (string str, int min, int max, string errMessage) {
            var result = int.Parse(str);
            if (result < min)
                throw new PareseIntError(errMessage);
            if (result > max)
                throw new PareseIntError(errMessage);
            return result;
        }
    }
}
