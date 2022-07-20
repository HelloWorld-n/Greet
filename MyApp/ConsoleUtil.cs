public class ConsoleUtil {

	public class ConsoleColor {
		private int _red;
		private int _green;
		private int _blue;
		
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
