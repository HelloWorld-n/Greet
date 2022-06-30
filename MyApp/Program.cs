using static System.DateTime;
using static System.TimeSpan;
using static System.Random;
using static ConsoleUtil;

class Program{	
	public static Random rnd = new Random();
	public static DateTime now = DateTime.Now;
	public static DateTime previous = now;
	public static TimeSpan delta_now = now - previous;
	
	public static void UpdateInfo(){
		var delay = 70;
		var delta_delay = 32;
		var delta_delta_delay = 8;
		while (true){
			Thread.Sleep(delay / (rnd.Next(1, 12) * rnd.Next(1, 12)));
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
			warningColor[0] = warningShade + (255 - max_warningShade); 
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
			ConsoleUtil.ApplyForegroundColor(64, 192, 192);	
			Console.Write($"Last time updated at ");
			ConsoleUtil.ApplyForegroundColor(128, 255, 255);	
			Console.Write(now.ToString("yyyy-MM-dd'T'HH:mm:ssK"));
			ConsoleUtil.ApplyForegroundColor(64, 192, 192);	
			Console.WriteLine($"。");

			ConsoleUtil.ApplyForegroundColor(127, 127, 127);	
			if (delta_now.TotalSeconds > 5){
				Console.Write($"There is delay of ");
				ConsoleUtil.ApplyForegroundColor(192, 192, 192);	
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
				ConsoleUtil.ApplyForegroundColor(127, 127, 127);
				Console.WriteLine($"。");
			}
			
			if (delta_now.TotalSeconds > 30){
				ConsoleUtil.ApplyForegroundColor(warningColor[0], warningColor[1], warningColor[2]);
				Console.WriteLine($"Warning: recommended immediate restrart!");
			}
			ConsoleUtil.ApplyDefaultColors();
			Thread.Sleep(1);
		}
	}

	public static void Main(string[] args){
		new Thread(new ThreadStart(UpdateInfo)).Start();
		new Thread(new ThreadStart(UpdateScreen)).Start();
	}
}
