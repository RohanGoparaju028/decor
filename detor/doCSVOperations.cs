using System;
using System.Collections.Generic;
using System.Linq;
namespace detor {
  public class doingPreprocssingStepsONCSV{
	  /*describe gives you 
	   * 1)count
	   * 2)mean
	   * 3)std deviation
	   * 4)Min
	   * 5)Max
	   * 6)25%
	   * 7)50%
	   * 8)75%
	   * */
	 private double Mean(List<double> val) {
		  if(val == null || val.Count == 0) {
			  return 0.0;
		  }
		  return val.Average();
	  }
	  private double StandardDeviation(List<double> x) {
		  int n = x.Count;
		   double mean = Mean(x);
		  double num = x.Sum(val => Math.Pow(val-mean,2));
		  return Math.Sqrt(num/n);
	  }
	  private double Max(List<double> x) {
		  if(x == null || x.Count == 0) {
			  return 0.0;
		  }
		  return x.Max();
	  }
	  private double Min(List<double> x) {
		  if(x == null || x.Count == 0) {
			  return 0.0;
		  }
		  return x.Min();
	  }
	  private double Percentile(List<double> x,double percentile){
		  if(x == null || x.Count == 0) {
			  return 0.0;
		  }
		  x.Sort();
		  double percent = (percentile/100.0)*(x.Count+1);
		  int idx = (int) Math.Floor(percent)-1;
		  if(idx < 0) x.First();
		  if(idx>=x.Count) return x.Last();
		  return x[idx];
	  }
	  public void describe(List<object[]> data) {
		  if(data == null || data.Count == 0) {
			  throw new Exception("the input cannot be empty please load the data befor parsing it for numerical computations");
		  }
		  int rows = data.Count;
		  int cols = data[0].Length;
		  List<double> input = new List<double>();
		  for(int col = 0;col < cols;col++) {
			  for(int row = 1;row<rows;row++) {
				  if(data[row][col] is int intval) {
					  input.Add(intval);
				  } else if(data[row][col] is double doubleVal) {
					  input.Add(doubleVal);
				  }
			  }
			  if(input.Count > 0) {
				  double mean = Mean(input);
				  double std = StandardDeviation(input);
				  double max = Max(input);
				  double min = Min(input);
				  double pert25 = Percentile(input,25.0);
				  double pert50 = Percentile(input,50.0);
				  double pert75 = Percentile(input,75.0);
				  Console.WriteLine($"{data[0][col]}");
				  Console.WriteLine($"Mean ${mean}");
				  Console.WriteLine($"Standard Deviation {std}");
				  Console.WriteLine($"Max {max}");
				  Console.WriteLine($"Min {min}");
				  Console.WriteLine($"25% {pert25}");
				  Console.WriteLine($"50% {pert50}");
				  Console.WriteLine($"75% {pert75}");
				  input.Clear();
			  }
		  }

	  }
	  public void isNullSum(List<object[]> input) {
		  if(input == null || input.Count == 0) {
			  throw new Exception("the input cannot be empty please load th e data befor finding the null values in the csv file");
		  }
		  //Dictionary<string,int> data = new Dictionary<string,int>();
		  int rows = input.Count;
		  int cols = input[0].Length;
		  for(int col = 0;col<cols;col++) {
			  int nullCount = input.Skip(0).Count(row => row[col] == null);
			  Console.WriteLine($"Coloumn:Sum");
			  Console.WriteLine($"{input[0][col]}:{nullCount}");
			  }
		  }
	  }
  }
