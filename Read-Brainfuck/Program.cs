namespace Read_Brainfuck;

class Program
{
    static void Main(string[] args) //metoda main 
    {
        
        if (args.Length == 1 && args[0] == "-h") //informacje argument -h
        {
            Console.WriteLine("\n  author : Łukasz Kielczyk\n");
            Console.WriteLine(" Read-Brainfuck: A program that interprets the Brainfuck source language\n" +
                              "\nTo read information stored in file as BF code, start the program\n" +
                              "     adding an argument -p <path>, where the path corresponds to the location of the file you want to interpret");
            Console.WriteLine("\nexample:\n Read-Brainfuck -p C:\\Users\\user\\Desktop\\file.bf");
        }
        else
        if (args.Length == 2 && args[0] == "-p") //reakcja na argument -p <sciezka pliku>
        {
            string input = args[1]; //zapisanie sciezki do zmiennej input
            if (File.Exists(input)) //sprawdza czy podano poprawnie, jesli tak wczytuje zawartosc pliku do zmiennej code
            {
                string code = File.ReadAllText(input);
                // test 1: Console.WriteLine(code);
                Interpreter(code);
                Console.WriteLine();
            }
            else//jezeli nie moze odnalezc pliku
            {
                Console.WriteLine($"Cannot find '{input}' \n the file doesn't exist or the path is invalid");
            }
        }
        else// reakcja na nieprawidlowe uruchomienie programu
        {
            Console.WriteLine("Unknown operation. Use the -h argument to display more information");
        }
    }//koniec Main

    public static void Interpreter(string code) // metoda zaczytujaca kod, ktora tworzy tablice bytow na ktorej bedzie bedzie pracowal kod
    {
        const int memorySize = 30000; //ustala rozmiar dla pamieci 
        byte[]memory = new byte[memorySize]; //tworzy wirtualna tasme pamieci
        int pointer = 0; //ustawia wskaznik na 1 pozycje tasmy
        int codeindex = 0; //ustawia poczatkowa pozycje wskaznika dla kodu z pliku na pierwszy znak

        while (codeindex < code.Length) //petla czytajaca kod
        {
            switch (code[codeindex]) //operuje na memory na podstawie znakow z kodu na wejsciu
            {
                case '>': //przesowa wskaznik na tasmie w prawo
                    pointer = (pointer + 1) % memorySize;
                    break;
                case '<': //przesowa wskaznik na tasmie w lewo
                    pointer = (pointer + memorySize - 1) % memorySize;
                    break;
                case '+': //zwieksza wartosc dla komorki wskazanej przez wskaznik
                    memory[pointer]++;
                    break;
                case '-': //zmniejsza wartosc dla komorki 
                    memory[pointer]--;
                    break;
                case '.': //odczytuje wartosc komorki wypisujac ja na ekran w formie znaku z tablicy ascii
                    Console.Write((char)memory[pointer]);
                    break;
                case ',': //wczytuje wartosc komorki 
                    memory[pointer] = (byte)Console.Read();
                    break;
                case '[': //sprawdza wartosc komorki czy = 0 jesli tak szuka konca petli w kodzie do ktorego skacze
                    if (memory[pointer] == 0)
                    {
                        int endloop = FindBrackets(code, codeindex);
                        if (endloop == -1)
                            Console.WriteLine("Can't find the end of loop");
                        codeindex = endloop;
                    }
                    break;
                case ']': //sprawdza wartosc komorki czy > 0 jesli tak szuka poczatku petli do ktorego przeskakuje
                    if (memory[pointer] > 0)
                    {
                        int startloop = FindBrackets(code, codeindex, true);
                        if (startloop == -1)
                            Console.WriteLine("Can't find the beginning of loop");
                        codeindex = startloop -1;
                    }
                    break;
                default:
                    break;
            }
            codeindex++; //nastepny znak z wejscia
        } //koniec petli 
    } //koniec metody interpreter

    public static int FindBrackets(string code, int codeindex, bool reverse = false) //metoda szukania krancow petli i zagniezdzen
    {
        int direction = reverse ? -1 : 1; //przeszukuje w prawo lub lewo w zaleznosci od warunku 
        int nest = 1; //1 poziom bo otwiera petle
        for (int i = codeindex + direction; i >= 0 && i < code.Length; i += direction)
        {
            if (code[i] == '[')
                nest += reverse ? -1 : 1;
            if (code[i] == ']')
                nest += reverse ? 1 : -1;
            if (nest == 0)
                return i;
        }
        return -1;
    } //koniec metody
} //koniec Programu