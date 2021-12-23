using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookTo.Shared.Enums;

namespace CookTo.Shared.MeasureConvertors;

public static class LiquidConvertor
{
	/// <summary>
	/// Coverts uk fluid measures to a required measure, supported measures ml,l,pint,floz
	/// </summary>
	/// <param name="amount"></param>
	/// <param name="measureFrom"></param>
	/// <param name="measureTo"></param>
	/// <returns>Amount converted to required fluid measure as double</returns>
	public static double LiquidConvertion(double amount, MeasureUnit measureFrom, MeasureUnit measureTo) =>
		measureFrom switch
		{
			MeasureUnit.ml => MilliltersTo(amount, measureTo),
			MeasureUnit.l => LitreTo(amount, measureTo),
			MeasureUnit.pint => PintTo(amount, measureTo),
			MeasureUnit.floz => FluidOzTo(amount, measureTo),
		};

	private static double MilliltersTo(double amount, MeasureUnit measureTo) =>
		measureTo switch
		{
			MeasureUnit.floz => amount * 0.033814022558919,
			MeasureUnit.pint => amount * 0.0017598,
			MeasureUnit.l => amount * 0.001,
			_ => throw new NotSupportedException($"{Enum.GetName(measureTo)} not supported")
		};

	private static double FluidOzTo(double amount, MeasureUnit measureTo) =>
		measureTo switch
		{
			MeasureUnit.ml => amount / 0.033814022558919,
			MeasureUnit.pint => amount * 0.0500008,
			MeasureUnit.l => amount / 35.195,
			_ => throw new NotSupportedException($"{Enum.GetName(measureTo)} not supported")
		};

	private static double PintTo(double amount, MeasureUnit measureTo) => 
		measureTo switch
		{
			MeasureUnit.ml => amount / 0.0017598,
			MeasureUnit.floz => amount / 0.0500008,
			MeasureUnit.l => amount / 1.7598,
			_ => throw new NotSupportedException($"{Enum.GetName(measureTo)} not supported")
		};

	private static double LitreTo(double amount, MeasureUnit measureTo)
	{
		return measureTo switch
		{
			MeasureUnit.ml => amount / 1000,
			MeasureUnit.floz => amount * 35.195,
			MeasureUnit.l => amount * 1.7598,
					_ => throw new NotSupportedException($"{Enum.GetName(measureTo)} not supported")
		};
	}
}
