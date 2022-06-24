using static System.DateTime;
using static System.Random;

class Program{
	public const String esc = "\u001B"; 
	public static void Main(string[] args){
		int delay = 35;
		int delta_delay = 16;
		var rnd = new Random();
		var now = DateTime.Now;
		var previous = now;
		var delta_now = now - previous;
		while(true){
			previous = now;
			now = DateTime.Now;
			delta_now = (
				now - previous > delta_now
			) ? (
				now - previous
			) : (
				delta_now
			);
			Console.Clear();		
			Console.WriteLine($"Last time updated at {now.ToString("yyyy-MM-dd'T'HH:mm:ssK")}。");
			if (delta_now.TotalSeconds > 5){
				Console.WriteLine(
					$"{esc}[38;2;127;127;127mThere is delay of P" + (
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
			if (delta_now.TotalMinutes > 2.5){
				Console.WriteLine(
					$"{esc}[48;2;0;0;0m{esc}[38;2;255;127;127m"+
					$"Warning: recommended immediate reset!"+
					$"{esc}[00m"
				);
			}

			if (rnd.Next(0, 15) < 1){
				Thread.Sleep(delay);
			}
			delay += delta_delay;
			delta_delay += 1;
		}
	}
}

