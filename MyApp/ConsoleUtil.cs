class ConsoleUtil {
	protected const String esc = "\u001B";

	public static void ApplyBackgroundColor(int red, int green, int blue){
		Console.Write($"{esc}[48;2;{red};{green};{blue}m");
	}

	public static void ApplyForegroundColor(int red, int green, int blue){
		Console.Write($"{esc}[38;2;{red};{green};{blue}m");
	}

	public static void ApplyDefaultColors(){
		Console.Write($"{esc}[00m");
	}
}
