using static System.DateTime;
using static System.TimeSpan;
using static System.Random;
using static ConsoleUtil;

class Program{
	public static Random rnd = new Random();
	public static DateTime now = DateTime.Now;
	public static DateTime previous = now;
	public static TimeSpan delta_now = now - previous;

	public static readonly ConsoleUtil.ConsoleColor[] colors_time = {
		new ConsoleUtil.ConsoleColor(64, 192, 192),
		new ConsoleUtil.ConsoleColor(128, 255, 255),
	};
	public static readonly ConsoleUtil.ConsoleColor[] colors_delay = {
		new ConsoleUtil.ConsoleColor(127, 127, 127),
		new ConsoleUtil.ConsoleColor(192, 192, 192),
	};

	public static void UpdateInfo(){
		var delay = 200;
		var delta_delay = 50;
		var delta_delta_delay = 10;
		var min_sleep = 5;
		var max_sleep = 15;
		while (true){
			Thread.Sleep(delay / (rnd.Next(min_sleep, max_sleep) * rnd.Next(min_sleep, max_sleep)));
			previous = now;
			now = DateTime.Now;
			delay += delta_delay;
			delta_delay += delta_delta_delay;
		}
	}

	public static void UpdateScreen(){
		const int max_warningShade = 127;
		var warningShade = 0;
		var increase_warningShade = false;
		var warningColor = new int[3];
		while(true){
			if (warningShade < 0){
				warningShade = 0;
				increase_warningShade = true;
			}
			if (warningShade > max_warningShade){
				warningShade = max_warningShade;
				increase_warningShade = false;
			}
			warningShade += (increase_warningShade? (+1) : (-1));
			warningColor[0] = (255 - max_warningShade - 1) + warningShade;
			warningColor[1] = warningShade;
			warningColor[2] = warningShade;

			delta_now = (
				now - previous > delta_now
			) ? (
				now - previous
			) : (
				delta_now
			);
			ConsoleUtil.ApplyBackgroundColor(0, 0, 0);
			Console.Clear();
			ConsoleUtil.ApplyForegroundColor(colors_time[0]);
			Console.Write($"Last time updated at ");
			ConsoleUtil.ApplyForegroundColor(colors_time[1]);
			Console.Write(now.ToString("yyyy-MM-dd'T'HH:mm:ssK"));
			ConsoleUtil.ApplyForegroundColor(colors_time[0]);
			Console.WriteLine($"。");

			ConsoleUtil.ApplyForegroundColor(colors_delay[0]);
			if (delta_now.TotalSeconds > 5){
				Console.Write($"There is delay of ");
				ConsoleUtil.ApplyForegroundColor(colors_delay[1]);
				Console.Write(
					$"P" + (
						(
							delta_now.TotalDays > 1
						) ? (
							$"{delta_now.Days}DT"
						) : ($"T")
					) + (
						(
							delta_now.TotalHours > 1
						) ? (
							$"{delta_now.Hours}H"
						) : ($"")
					) +	(
						(
							delta_now.TotalMinutes > 1
						) ? (
							$"{delta_now.Minutes}M"
						) : ($"")
					) + $"{delta_now.Seconds}S"
				);
				ConsoleUtil.ApplyForegroundColor(colors_delay[0]);
				Console.WriteLine($"。");
			}

			if (delta_now.TotalSeconds > 30){
				ConsoleUtil.ApplyForegroundColor(warningColor[0], warningColor[1], warningColor[2]);
				Console.WriteLine($"Warning: recommended immediate restrart!");
			}
			ConsoleUtil.ApplyDefaultColors();
			Thread.Sleep(50);
		}
	}

	public static void Main(string[] args){
		new Thread(new ThreadStart(UpdateInfo)).Start();
		new Thread(new ThreadStart(UpdateScreen)).Start();
	}
}
