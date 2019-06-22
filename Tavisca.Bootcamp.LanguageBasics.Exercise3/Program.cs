using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
        int[] cal = new int[protein.Length];
		   int[] result = new int[dietPlans.Length];
		  
		   
		  
		   for(int i=0;i<protein.Length;i++)
		   {
			   cal[i]=protein[i]*5 + carbs[i]*5 + fat[i]*9;
		   }
		   
		   for(int i=0;i<dietPlans.Length;i++)
		   {
			   if(dietPlans[i]=="")
			   {
				   result[i] = 0;
			   }
			   else
			   {
				   result[i]=Result(protein,carbs,fat,cal,dietPlans[i],new List<int>());
			   }
		   }
		   
		   return result;
        }
		public static int Result(int[] protein,int[] carbs,int[] fat,int[] cal,string dietPlan,List<int> index)
		{	
			try
			{
				if(dietPlan.Length>0)
				{
					switch(dietPlan[0])
					{
						case 'P' :  index=findMax(protein,index);
									if(index.Count>1)
										return Result(protein,carbs,fat,cal,dietPlan.Substring(1),index);
									else
										return index[0];
						case 'p' :  index=findMin(protein,index);
									if(index.Count>1)
										return Result(protein,carbs,fat,cal,dietPlan.Substring(1),index);
									else
										return index[0];
						case 'C' :  index=findMax(carbs,index);
									if(index.Count>1)
										return Result(protein,carbs,fat,cal,dietPlan.Substring(1),index);
									else
										return index[0];
						case 'c' :  index=findMin(carbs,index);
									if(index.Count>1)
										return Result(protein,carbs,fat,cal,dietPlan.Substring(1),index);
									else
										return index[0];
						case 'F' :  index=findMax(fat,index);
									if(index.Count>1)
										return Result(protein,carbs,fat,cal,dietPlan.Substring(1),index);
									else
										return index[0];
						case 'f' :  index=findMin(fat,index);
									if(index.Count>1)
										return Result(protein,carbs,fat,cal,dietPlan.Substring(1),index);
									else
										return index[0];
						case 'T' :  index=findMax(cal,index);
									if(index.Count>1)
										return Result(protein,carbs,fat,cal,dietPlan.Substring(1),index);
									else
										return index[0];
						case 't' :  index=findMin(cal,index);
									if(index.Count>1)
										return Result(protein,carbs,fat,cal,dietPlan.Substring(1),index);
									else
										return index[0];
									
					}
				}
				else
					return index[0];
			
			}
			catch(ArgumentOutOfRangeException e)
			{
				Console.WriteLine(e);
			}
			return 0;
		}
		public static List<int> findMax(int[] cal,List<int> indexes)
		{
			int max,i;
			List<int> index1 = new List<int>();
			
			if(indexes.Count>0)
			{
				max=cal[index1[0]];
				foreach(int index in indexes)
				{
					if(max<cal[index])
						max=cal[index];
				}
				foreach(int index in indexes)
				{
					if(max==cal[index])
						index1.Add(index);
				}
				
			}
			else
			{
				max=cal[0];
				for(i=1;i<cal.Length;i++)
				{
					if(max<cal[i])
						max=cal[i];
				}
				for(i=0;i<cal.Length;i++)
				{
					if(max==cal[i])
						index1.Add(i);
				}
			}
			
			return index1;
		
		}
		
		public static List<int> findMin(int[] cal,List<int> indexes)
		{
			int min,i;
			List<int> index1 = new List<int>();
			
			if(indexes.Count>0)
			{
				min=cal[index1[0]];
				foreach(int index in indexes)
				{
					if(min>cal[index])
						min=cal[index];
				}
				foreach(int index in indexes)
				{
					if(min==cal[index])
						index1.Add(index);
				}
				
			}
			else
			{
				min=cal[0];
				for(i=1;i<cal.Length;i++)
				{
					if(min>cal[i])
						min=cal[i];
				}
				for(i=0;i<cal.Length;i++)
				{
					if(min==cal[i])
						index1.Add(i);
				}
			}
			
			return index1;
		
		}
        
        }
            
}
