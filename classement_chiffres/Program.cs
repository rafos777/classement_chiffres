List<int> chiffresAtrier = [1, 265, 36, 12, 87,2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19];
List<int> chiffrestries = [0];
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
foreach (var chiffre in chiffrestries)
{
    Console.WriteLine(chiffre);
}
Console.WriteLine("Fini");
