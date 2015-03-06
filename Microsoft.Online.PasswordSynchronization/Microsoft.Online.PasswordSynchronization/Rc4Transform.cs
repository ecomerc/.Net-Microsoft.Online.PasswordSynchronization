using System;
using System.Security.Cryptography;

namespace Microsoft.Online.PasswordSynchronization
{
	internal class Rc4Transform : ICryptoTransform
	{
		private byte[] key;

		public virtual bool CanReuseTransform
		{
			get
			{
				return false;
			}
		}

		public virtual bool CanTransformMultipleBlocks
		{
			get
			{
				return true;
			}
		}

		public virtual int InputBlockSize
		{
			get
			{
				return 1;
			}
		}

		public virtual int OutputBlockSize
		{
			get
			{
				return 1;
			}
		}

		public Rc4Transform(byte[] key)
		{
			this.key = key;
		}



		public virtual int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			if (inputBuffer == null)
			{
				throw new ArgumentNullException("inputBuffer");
			}
			if (outputBuffer == null)
			{
				throw new ArgumentNullException("outputBuffer");
			}
			if (inputOffset < 0)
			{
				throw new ArgumentOutOfRangeException("inputOffset", (object)inputOffset, "The inputOffset must be greater than zero.");
			}
			if (outputOffset < 0)
			{
				throw new ArgumentOutOfRangeException("outputOffset", (object)outputOffset, "The outputOffset must be greater than zero.");
			}
			if (inputOffset > inputBuffer.Length - inputCount)
			{
				throw new ArgumentOutOfRangeException("inputOffset", (object)inputOffset, "The input offset must be inside the bounds of the inputBuffer array.");
			}
			if (outputOffset > outputBuffer.Length - inputCount)
			{
				throw new ArgumentOutOfRangeException("outputOffset", (object)outputOffset, "The output offset must be inside the bounds of the outputBuffer array.");
			}
			if (inputCount == 0)
			{
				return 0;
			}
			/* modopt(System.Runtime.CompilerServices.IsExplicitlyDereferenced) */ byte* byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu0029 = &inputBuffer[inputOffset];
			/* modopt(System.Runtime.CompilerServices.IsExplicitlyDereferenced) */ byte* byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu00291 = &outputBuffer[outputOffset];
			ulong num = (ulong)inputCount;
			if (<Module>.memcpy_s(byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu00291, num, byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu0029, num) != null)
			{
				throw new IndexOutOfRangeException("Error while copying block.");
			}
			byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu0029 = (long)0;
			<Module>.rc4(this.key.Key, (uint)inputCount, byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu00291);
			
            return inputCount;
		}

		public virtual byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] numArray = new byte[inputCount];
			this.TransformBlock(inputBuffer, inputOffset, inputCount, numArray, 0);
			return numArray;
		}
	}
}