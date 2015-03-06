using System;
using System.Security.Cryptography;

namespace Microsoft.Online.PasswordSynchronization
{
	public class Rc4SymmetricAlgorithmOld : SymmetricAlgorithm
	{
		private const int MaxKeyByteSize = 256;

		private const int MaxKeyBitSize = 2048;

		private static KeySizes[] DefaultLegalKeySizes;

		private static KeySizes[] DefaultLegalBlockSizes;

		private static byte[] EmptyBytes;

		public override KeySizes[] LegalBlockSizes
		{
			get
			{
				return Rc4SymmetricAlgorithm.DefaultLegalBlockSizes;
			}
		}

		public override KeySizes[] LegalKeySizes
		{
			get
			{
				return Rc4SymmetricAlgorithm.DefaultLegalKeySizes;
			}
		}

		static Rc4SymmetricAlgorithm()
		{
			KeySizes[] keySize = new KeySizes[] { new KeySizes(8, 2048, 8) };
			Rc4SymmetricAlgorithm.DefaultLegalKeySizes = keySize;
			KeySizes[] keySizesArray = new KeySizes[] { new KeySizes(8, 8, 0) };
			Rc4SymmetricAlgorithm.DefaultLegalBlockSizes = keySizesArray;
			Rc4SymmetricAlgorithm.EmptyBytes = new byte[0];
		}

		public Rc4SymmetricAlgorithm()
		{
			try
			{
				this.KeySizeValue = 2048;
			}
		}

		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return this.CreateTransform(rgbKey);
		}

		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return this.CreateTransform(rgbKey);
		}

		private ICryptoTransform CreateTransform(byte[] key)
		{
			int length = key.Length;
			if (length > 256 || length < 1)
			{
				throw new ArgumentOutOfRangeException("key", (object)length, "The key length must be greater than 0 and less than or equal to 256.");
			}
			return new Rc4Transform(key);
		}

		public override void GenerateIV()
		{
			this.IV = Rc4SymmetricAlgorithm.EmptyBytes;
		}

		public override void GenerateKey()
		{
			byte[] numArray = new byte[4];
			(new RNGCryptoServiceProvider()).GetBytes(numArray);
			Random random = new Random(BitConverter.ToInt32(numArray, 0));
			byte[] numArray1 = new byte[16];
			random.NextBytes(numArray1);
			this.Key = numArray1;
		}
	}
}