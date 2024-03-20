using System.Diagnostics;
using System.Numerics;
using System.Timers;

var chiffresAtrier = new List<int>();
var chiffrestries = new List<int>();

void MoveMinimum()
{
    do
    {
        int min = int.MaxValue;
        int minIndex = 0;

        // trouver minimum dans tableau
        for (int i = 0; i < chiffresAtrier.Count; i++)
        {
            int value = chiffresAtrier[i];
            if (value < min)
            {
                min = value;
                minIndex = i;
            }
        }

        // ajouter minimum dans nouveau tableau
        chiffrestries.Add(min);

        // effacer minimum
        chiffresAtrier.RemoveAt(minIndex);
    }
    while (chiffresAtrier.Count > 0);
}


#region generation
int seed = DateTime.Now.Second;
Random rnd = new Random(seed);

Stopwatch sw = Stopwatch.StartNew();

for (int indexrdm=0; indexrdm< 60000; indexrdm++)
{
    int randomValue = rnd.Next(0, 100000);

    // verifie si la value aléatoire n'existe pas dans le tableau
    bool addValue = true;
    for (int i=0; i<chiffresAtrier.Count; i++)
    {
        if (randomValue == chiffresAtrier[i])
        {
            addValue = false;

            /*
            if(indexrdm>10000)
            {
                Console.WriteLine($"FOUND at {i}! Index {indexrdm}, value = {randomValue}");
            }*/

        }


    }

    if(addValue)
    {
        chiffresAtrier.Add(randomValue);
    }    
}

sw.Stop();
Console.WriteLine($"Generation = {sw.ElapsedMilliseconds/1000.0f}");
#endregion

Stopwatch timer = new Stopwatch();
timer.Start();

MoveMinimum();

timer.Stop();

Console.WriteLine($"Fini en {timer.ElapsedMilliseconds / 1000.0f} s");
