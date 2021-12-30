using CookTo.Shared.Enums;
using System;
using System.Linq;

namespace CookTo.Shared.MeasureConvertors;

public class DryConveter
{
	/// <summary>
	/// Coverts uk weights to a required weight, supported weights, g,kg,lb,oz
	/// </summary>
	/// <param name="amount"></param>
	/// <param name="measureFrom"></param>
	/// <param name="measureTo"></param>
	/// <returns>Amount converted to required dry weight</returns>
	public static double DryConvertion(double amount, MeasureUnit measureFrom, MeasureUnit measureTo) =>
		measureFrom switch
		{
			MeasureUnit.g => GramsTo(amount, measureTo),
			MeasureUnit.kg => KiloTo(amount, measureTo),
			MeasureUnit.oz => OunceTo(amount, measureTo),
			MeasureUnit.lb => PoundTo(amount, measureTo),
			_ => throw new NotSupportedException($"{Enum.GetName(measureFrom)} not supported")
		};
	private static double GramsTo(double amount, MeasureUnit measureTo) =>
		measureTo switch
		{
			MeasureUnit.kg => amount * 1000,
			MeasureUnit.oz => amount * 0.03527,
			MeasureUnit.lb => amount * 0.002205,
			_ => throw new NotSupportedException($"{Enum.GetName(measureTo)} not supported")
		};

	private static double KiloTo(double amount, MeasureUnit measureTo) =>
		measureTo switch
		{
			MeasureUnit.g => amount / 1000,
			MeasureUnit.oz => amount * 35.274,
			MeasureUnit.lb => amount * 2.2046,
			_ => throw new NotSupportedException($"{Enum.GetName(measureTo)} not supported")
		};

	private static double OunceTo(double amount, MeasureUnit measureTo) =>
		measureTo switch
		{
			MeasureUnit.kg => amount / 35.274,
			MeasureUnit.g => amount / 0.03527,
			MeasureUnit.lb => amount * 0.0625,
			_ => throw new NotSupportedException($"{Enum.GetName(measureTo)} not supported")
		};

	private static double PoundTo(double amount, MeasureUnit measureTo) =>
		measureTo switch
		{
			MeasureUnit.kg => amount / 2.2046,
			MeasureUnit.oz => amount / 0.0625,
			MeasureUnit.g => amount / 0.002205,
			_ => throw new NotSupportedException($"{Enum.GetName(measureTo)} not supported")
		};
}


