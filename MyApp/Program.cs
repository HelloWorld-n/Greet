using static System.DateTime;
using static System.TimeSpan;
using static System.Random;

class Program{
	public const String esc = "\u001B"; 
	
	public static Random rnd = new Random();
	public static DateTime now = DateTime.Now;
	public static DateTime previous = now;
	public static TimeSpan delta_now = now - previous;
	
	public static void UpdateInfo(){
		var delay = 55;
		var delta_delay = 26;
		var delta_delta_delay = 5;
		while (true){
			Thread.Sleep(delay / (rnd.Next(1, 10) * rnd.Next(1, 10)));
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
			Console.Clear();		
			Console.WriteLine($"{esc}[48;2;0;0;0m{esc}[38;2;64;192;192mLast time updated at {now.ToString("yyyy-MM-dd'T'HH:mm:ssK")}。{esc}[00m");
			if (delta_now.TotalSeconds > 5){
				Console.WriteLine(
					$"{esc}[48;2;0;0;0m{esc}[38;2;127;127;127mThere is delay of P" + (
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
					) + $"{delta_now.Seconds}S。{esc}[00m"
				);
			}
			if (delta_now.TotalMinutes > 1.5){
				Console.WriteLine(
					$"{esc}[48;2;0;0;0m{esc}[38;2;{warningColor[0]};{warningColor[1]};{warningColor[2]}m"+
					$"Warning: recommended immediate reset!"+
					$"{esc}[00m"
				);
			}
			Thread.Sleep(1);
			
		}
	}

	public static void Main(string[] args){
		new Thread(new ThreadStart(UpdateInfo)).Start();
		new Thread(new ThreadStart(UpdateScreen)).Start();
	}
}

