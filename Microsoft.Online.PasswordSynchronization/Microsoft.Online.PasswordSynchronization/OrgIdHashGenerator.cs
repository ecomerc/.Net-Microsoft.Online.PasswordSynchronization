
using System;

namespace Microsoft.Online.PasswordSynchronization
{
	public sealed class OrgIdHashGenerator
	{
		private const string DefaultConfiguration = "v1;PPH1,10,100;";

		private OrgIdHashGenerator()
		{
		}

		public static string Generate(string configuration, string data)
		{
			//TODO!!!!
            return "";

		}

		public static string Generate(string data)
		{
			return OrgIdHashGenerator.Generate("v1;PPH1,10,100;", data);
		}
	}
}