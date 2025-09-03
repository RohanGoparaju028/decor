namespace detor;

public class Class1
{
   static void Main() {
	   ReadFiles read = new ReadFiles();
	   var data = "data.csv";
	   var result = read.readCSV(data);
	   doingPreProcessingStepsONCSV dco = new doingPreprocessingStepsONCSV();
            dco.describe(result);
	    dco.isNullSum(result);
   }
}
