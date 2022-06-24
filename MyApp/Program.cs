using static System.DateTime;
using static System.Random;

class Program{
	public static void Main(string[] args){
		int delay = 25;
		int delta_delay = 10;
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
					"There is delay of p" + (
						(
							delta_now.TotalDays > 1
						) ? (
							$"{delta_now.Days}Dt"
						) : ("t") 
					) + (
						(
							delta_now.TotalHours > 1
						) ? (
							$"{delta_now.Hours}H"
						) : ("") 
					) +	(
						(
							delta_now.TotalMinutes > 1
						) ? (
							$"{delta_now.Minutes}M"
						) : ("")
					) + $"{delta_now.Seconds}S。"
				);
			}
			if (delta_now.TotalMinutes > 2.5){
				Console.WriteLine(
					"\u001B[48;2;0;0;0m\u001B[38;2;255;0;0m"+
					"Warning: recommended immediate reset!"+
					"\u001B[00m"
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

