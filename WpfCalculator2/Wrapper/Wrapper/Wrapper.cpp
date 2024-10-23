#include "pch.h"

#include "Wrapper.h"

namespace Wrapper
{
	int MyArithmetic::Add(int a, int b)
	{
		return a + b;
	}

	int MyArithmetic::Subtract(int a, int b)
	{
		return a - b;
	}

	float MyArithmetic::Multiply(float a, float b)
	{
		return a * b;
	}

	float MyArithmetic::Divide(float a, float b)
	{
		return a / b;
	}
}