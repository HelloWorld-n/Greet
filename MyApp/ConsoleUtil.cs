public class ConsoleUtil {
	public class ConsoleColor {
		private int _red;
		private int _green;
		private int _blue;
		
		public static readonly ConsoleColor Black = new ConsoleColor(0, 0, 0);
		public static readonly ConsoleColor DarkGray = new ConsoleColor(63, 63, 63);
		public static readonly ConsoleColor Gray = new ConsoleColor(127, 127, 127);
		public static readonly ConsoleColor BrightGray = new ConsoleColor(191, 191, 191);
		public static readonly ConsoleColor White = new ConsoleColor(255, 255, 255);

		public static readonly ConsoleColor Red = new ConsoleColor(255, 0, 0);
		public static readonly ConsoleColor Orange = new ConsoleColor(191, 63, 0);
		public static readonly ConsoleColor Yellow = new ConsoleColor(127, 127, 0);
		public static readonly ConsoleColor Lime = new ConsoleColor(63, 191, 0);
		public static readonly ConsoleColor Green = new ConsoleColor(0, 255, 0);
		public static readonly ConsoleColor Cyan = new ConsoleColor(0, 127, 127);
		public static readonly ConsoleColor Blue = new ConsoleColor(0, 0, 255);
		public static readonly ConsoleColor Purple = new ConsoleColor(127, 0, 127);

		public int red {
			get {
				return _red;
			}	
		}
		
		public int green {
			get { 
				return _green;
			}
		}

		public int blue {
			get {
				return _blue;
			}
		}

		public ConsoleColor(int red, int green, int blue){
			this._red = red;
			this._green = green;
			this._blue = blue;
		}
	}


	protected const String esc = "\u001B";

	public static void ApplyBackgroundColor(int red, int green, int blue){
		ApplyBackgroundColor(new ConsoleColor(red, green, blue));
	}

	public static void ApplyBackgroundColor(ConsoleColor color){
		Console.Write($"{esc}[48;2;{color.red};{color.green};{color.blue}m");
	}

	public static void ApplyForegroundColor(int red, int green, int blue){
		ApplyForegroundColor(new ConsoleColor(red, green, blue));
	}

	public static void ApplyForegroundColor(ConsoleColor color){
		Console.Write($"{esc}[38;2;{color.red};{color.green};{color.blue}m");
	}

	public static void ApplyDefaultColors(){
		Console.Write($"{esc}[00m");
	}
}
