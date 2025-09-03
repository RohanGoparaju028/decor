using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
namespace detor {
	public class ReadFiles{
		public List<object[]> readCSV(string csv) {
			if(!File.Exists(csv)) {
				throw new Exception("csv file does not exist in the current directory,please have the csvfile in the directory");
			}
			if(Path.GetExtension(csv) != ".csv") {
				throw new Exception("The file you are trying to use is not a csv file and this function explicitly required u to pass a csv file,please pass a file that has ends with .csv");
			}
			List<object[]> rows = new List<object[]>();
			foreach(var lines in File.ReadAllLines(csv)) {
				var cols = lines.Split(',');
				var currentRows = new object[cols.Length];
				for(int i=0;i<cols.Length;i++) {
					if(int.TryParse(cols[i],out int res)) {
						currentRows[i] = res;
					}
				else if(double.TryParse(cols[i],out double val)){
					      currentRows[i] = val;
					} 
					else{
						currentRows[i] = cols[i];
					}
				}
				rows.Add(currentRows);
			}
			return rows;
		}
	}
}
