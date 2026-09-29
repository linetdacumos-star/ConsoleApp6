using System;
using System.Collections;
using System.Collections.Generic;

namespace EXAM
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] scores = new int[3, 3];

            string[] names = new string[3];
            int[] totals = new int[3];
            int[] sortedIndices = { 0, 1, 2 };

            bool isRecorded = false;
            bool exit = false;
            
            while (!exit)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("   COMMUNITY FUN RUN SYSTEM   ");
                Console.WriteLine("==============================");
                Console.WriteLine("[1] RECORD SCORES");
                Console.WriteLine("[2] SHOW PARTICIPANT SCORES");
                Console.WriteLine("[3] SHOW RANKING");
                Console.WriteLine("[4] EXIT");
                Console.WriteLine("\nEnter Choice: ");
                
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("1 - RECORD SCORES");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write($"\nEnter name for Participant {i + 1}: ");
                            names[i] = Console.ReadLine();

                            int totalSum = 0;
                            for (int r = 0; r < 3; r++)
                            {
                                Console.Write($" Enter score for Round {r + 1}: ");
                                scores[i, r] = int.Parse(Console.ReadLine());
                                totalSum += scores[i, r];
                            }
                            totals[i] = totalSum;
                        }
                        isRecorded = true;
                        Console.WriteLine("Scores successfully recorded!\n");
                        break;

                    case "2":
                        Console.WriteLine("2 - SHOW PARTICIPANT SCORES");
                        if (!isRecorded)
                        {
                            Console.WriteLine("Please record participant scores first!\n");
                            break;
                        }
                        Console.WriteLine($"{"PARTICIPANT",-12} {"R1",-5} {"R2",-5} {"R3",-5} {"TOTAL",-5}");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine($"{names[i],-12} {scores[i, 0],-5} {scores[i, 1],-5} {"scores[i, 2]",-5} {totals[i],5}");
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.WriteLine("3 - SHOW RANKING");
                        if (!isRecorded)
                        {
                            Console.WriteLine("Please record participant scores first!\n");
                            break;
                        }
                        int[] tempTotals = (int[])totals.Clone();
                        int[] tempIndices = { 0, 1, 2 };

                        int passNumber = 1;
                        int n = tempTotals.Length;

                        for (int i = 0; i < n-1; i++)
                        {
                            bool swapped = false;
                            for (int j = 0; j < n - 1; j++)
                            {
                                if (tempTotals[j] < tempTotals[j + 1])
                                {
                                    int tempScore = tempTotals[j];
                                    tempTotals[j] = tempTotals[j + 1];
                                    tempTotals[j + 1] = tempScore;

                                    int tempIdx = tempIndices[j];
                                    tempIndices[j] = tempIndices[j + 1];
                                    tempIndices[j + 1] = tempIdx;

                                    swapped = true;
                                }
                            }

                            Console.WriteLine($"Pass {passNumber}: {tempTotals[0]} {tempTotals[1]} {tempTotals[2]}");
                            passNumber++;

                            if (!swapped) break;
                        }

                        Console.WriteLine("\nThen Display:");
                        Console.WriteLine("FUN RUN RANKING\n");
                        for (int i = 0; i < 3; i++)
                        {
                            int originalIndex = tempIndices[i];
                            Console.WriteLine($"{i + 1}. {names[originalIndex],-8} - {totals[originalIndex]}");
                        }
                        Console.WriteLine();
                        break;

                    case "4":
                        Console.WriteLine("4 - EXIT");
                        Console.WriteLine("Terminating the Program...");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option! Please enter a choice between 1 and 4.\n");
                        break;
                }
            }
        }
    }
}