﻿namespace Read_Brainfuck;

class Program
{
    static void Main(string[] args) //metoda Main obslugujaca wywolania argumetow
    {
        
        if (args.Length == 1 && args[0] == "-h") //help i info argument -h
        {
            Console.WriteLine("\n     Łukasz Kielczyk\n");
            Console.WriteLine(" Read-Brainfuck: program interpretujący język źródłowy brainfuck\n" +
                              "\n-p <scieżka>   Aby odczytac informacje zapisane w pliku z kodem bf nalezy uruchamiając program\n" +
                              "     dopisac argument -p <scieżka> gdzie scieżka odpowiada lokalizacji pliku który chcemy otworzyc");
            Console.WriteLine("\nprzykład:\n Read-Brainfuck.exe -p \" C:\\Users\\user\\Desktop\\plik.bf\"");
        }
        else
        if (args.Length == 2 && args[0] == "-p") //reakcja na argument -p <sciezka pliku>
        {
            string input = args[1]; //zapisanie sciezki do zmiennej input
            if (File.Exists(input)) //sprawdza czy podano poprawnie, jesli tak wczytuje zawartosc pliku do zmiennej code
            {
                string code = File.ReadAllText(input);
                Console.WriteLine(code);
            }
            else//jezeli nie moze odnalezc pliku
            {
                Console.WriteLine($"Nie mozna odnalezc '{input}' \n plik nie istnieje lub podano nieprawidlowa scieżke");
            }
        }
        else// reakcja na nieprawidlowe uruchomienie programu
        {
            Console.WriteLine("Nieznana operacja. Użyj -h, aby wyświetlić pomoc");
        }
    }//koniec Main

    public static void Interpreter(string code) // metoda zaczytujaca kod, ktora tworzy tablice bytow na ktorej bedzie bedzie pracowal kod
    {
        const int MEMORY_SIZE = 30000; //ustala rozmiar dla pamieci 
        byte[]memory = new byte[MEMORY_SIZE]; //tworzy wirtualna tasme 
        int pointer = 0; //ustawia wskaznik na 1 pozycje tasmy
        int codeindex = 0; //ustawia poczatkowa pozycje wskaznika dla zaczytanego kodu

        while (codeindex < code.Length) //petla czytajaca kod
        {
            switch (code[codeindex])
            {
                
            }
            codeindex++;
        } //koniec petli 
    }
}//koniec Programu