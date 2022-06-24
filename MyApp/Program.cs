using static System.DateTime;

class Program{
	public static void Main(string[] args){
		int delay = 10;
		int delta_delay = 1;
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
					"There is delay of " + (
						(
							delta_now.TotalDays > 1
						) ? (
							$"{delta_now.Days} days + "
						) : ("") 
					) + (
						(
							delta_now.TotalHours > 1
						) ? (
							$"{delta_now.Hours} hours + "
						) : ("") 
					) +	(
						(
							delta_now.TotalMinutes > 1
						) ? (
							$"{delta_now.Minutes} minutes + "
						) : ("")
					) + $"{delta_now.Seconds} seconds。"
				);
			}
			if (delta_now.TotalMinutes > 5){
				Console.WriteLine(
					"\u001B[48;2;0;0;0m\u001B[38;2;255;0;0m"+
					"Warning: recommended immediate reset!"+
					"\u001B[00m"
				);
			}

			Thread.Sleep(delay);
			delay += delta_delay;
			delta_delay += 1;
		}
	}
}

