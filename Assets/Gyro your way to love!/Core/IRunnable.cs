namespace Gyro_your_way_to_love_.Core
{
	public interface IRunnable
	{
		bool Enabled { get; set; }

		void Setup(params object[] _params);
		void Run(params object[] _params);
	}
}