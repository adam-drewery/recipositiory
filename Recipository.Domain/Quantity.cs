namespace Recipository.Domain
{
	public class Quantity
	{
		public Quantity() { }

		public Quantity(int measurement, Unit unit)
		{
			Measurement = measurement;
			Unit = unit;
		}

		public int Measurement { get; set; }

		public Unit Unit { get; set; }

		public static Quantity Slices(int number) => new Quantity(number, Unit.Slices);

		public static Quantity Grams(int number) => new Quantity(number, Unit.Grams);

		public static Quantity Ounces(int number) => new Quantity(number, Unit.Ounces);

		public static Quantity Chunks(int number) => new Quantity(number, Unit.Chunks);

		public static Quantity Cloves(int number) => new Quantity(number, Unit.Cloves);
	}
}
