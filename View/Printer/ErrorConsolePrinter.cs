using System.Transactions;

namespace View.Printer;

public class ErrorConsolePrinter() : BoxedContentPrinter(ConsoleColor.Red);