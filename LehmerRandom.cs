/// <summary>
/// https://en.wikipedia.org/wiki/Lehmer_random_number_generator
/// </summary>
internal class LehmerRandom
{
	private const int g = 16807; //7^5
	private const int n = 2147483647; //2^31 − 1
	private int _seed;

	public LehmerRandom(int seed)
	{
		SetSeed(seed);
	}

	private int next()
	{
		//cast to long to prevent overflow
		long result = ((long)_seed * g) % n;

		_seed = (int)result;

		return _seed;
	}

	/// <summary>
	/// Returns a random integer that is within a specified range.
	/// </summary>
	/// <param name="minValue"></param>
	/// <param name="maxValue"></param>
	/// <returns></returns>
	public int Next(int minValue, int maxValue)
	{
		if (minValue > maxValue)
			throw new ArgumentOutOfRangeException();

		int range = maxValue - minValue;

		return (next() % range) + minValue;
	}

	public void SetSeed(int seed)
	{
		if (seed == 0)
			seed = 1;

		_seed = seed;
	}
}