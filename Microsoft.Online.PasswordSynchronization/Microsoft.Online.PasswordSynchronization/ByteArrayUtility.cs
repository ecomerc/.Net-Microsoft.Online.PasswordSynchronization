using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.Online.PasswordSynchronization
{
	public static class ByteArrayUtility
	{
		private const string UpperCaseFormat = "{0:X2}";

		private const string LowerCaseFormat = "{0:x2}";

        /*
		public static byte[] ToByteArray(string value)
		{
			int num;
			byte num1 = 0;
			byte num2 = 0;
			if (value != null)
			{
				value = value.Trim();
				if (value != string.Empty)
				{
					if (value.Length % 2 != 0)
					{
						throw new ArgumentException("The input length must be a multiple of two.");
					}
					num = (value.Length <= 2 || (ushort)(value[1] | ' ') != 120 || value[0] != '0' ? 0 : 2);
					byte[] numArray = new byte[(value.Length - num) / 2];
					int num3 = num;
					int num4 = 0;
					if (num < value.Length)
					{
						while (ByteArrayUtility.ParseNibble(value[num3], ref num2) && ByteArrayUtility.ParseNibble(value[num3 + 1], ref num1))
						{
							numArray[num4] = (byte)(num2 << 4 | num1);
							num3 = num3 + 2;
							num4++;
							if (num3 < value.Length)
							{
								continue;
							}
							return numArray;
						}
						object[] objArray = new object[] { value };
						throw new FormatException(string.Format(CultureInfo.InvariantCulture, "The value '{0}' is not a valid hex string.", objArray));
					}
					return numArray;
				}
			}
			throw new ArgumentException("The input parameter cannot be null or an empty string.");
		}
        */


        public static byte[] ToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

		public static string ToHexString(this byte[] byteArray, bool caps)
		{
			/* modopt(System.Runtime.CompilerServices.IsConst) */ string stringu0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsConstu0029s;
			if (byteArray == null)
			{
				throw new ArgumentNullException("byteArray");
			}
			StringBuilder stringBuilder = new StringBuilder(byteArray.Length * 2);
			stringu0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsConstu0029s = (!caps ? "{0:x2}" : "{0:X2}");
			int num = 0;
			if (0 < byteArray.Length)
			{
				do
				{
					object[] objArray = new object[] { byteArray[num] };
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, stringu0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsConstu0029s, objArray);
					num++;
				}
				while (num < byteArray.Length);
			}
			return stringBuilder.ToString();
		}

		public static string ToHexString(this byte[] byteArray)
		{
			return byteArray.ToHexString(false);
		}
	}
}