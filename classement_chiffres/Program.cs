using System.Diagnostics;
using System.Timers;

List<int> chiffresAtrier = [];
List<int> chiffrestries = [0];

int seed = DateTime.Now.Second;
Random rnd = new Random(seed);

Stopwatch sw = Stopwatch.StartNew();

for (int indexrdm=0; indexrdm<60000;indexrdm++)
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

Stopwatch timer = new Stopwatch();
timer.Start();

//prend les chiffres de la liste "chiffresAtrier" dans l'ordre
for (int index1 = 0; index1 < chiffresAtrier.Count; )
{
    int chiffre1 = chiffresAtrier[index1];


    for (int index2 = 0; index2 < chiffresAtrier.Count; index2++)
    {
        int chiffre2 = chiffresAtrier[index2];
        if (chiffre2 != chiffre1)
        {
            if (chiffre2 < chiffre1)
            {
                int temp = chiffre1;
                chiffre1 = chiffre2;
                chiffre2 = temp;
            }
        }

    }
    for (int index3 = 0;index3<chiffrestries.Count;index3++)
    {
        if (chiffre1 != chiffrestries[index3])
        {
            if (index3<chiffrestries.Count )
            {
                chiffrestries.Add(chiffre1);
                chiffresAtrier.Remove(chiffre1);
                index3= index3+chiffrestries.Count;
            
            }
        }
    }
    
}
chiffrestries.Remove(0);

timer.Stop();

Console.WriteLine($"Fini en {timer.ElapsedMilliseconds / 1000.0f} s");
