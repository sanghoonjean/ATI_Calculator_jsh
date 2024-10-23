#pragma once

using namespace System;

namespace Wrapper {
	public ref class MyArithmetic
	{
	public:
		int Add(int a, int b);
		int Subtract(int a, int b);
		float Multiply(float a, float b);
		float Divide(float a, float b);
	};
}