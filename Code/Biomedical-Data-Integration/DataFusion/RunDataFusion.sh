mvn compile

mvn exec:java -Dexec.mainClass="genes.DataFusion.solution.DataFusion_Brain"
mvn exec:java -Dexec.mainClass="genes.DataFusion.solution.DataFusion_Cerebellum"
mvn exec:java -Dexec.mainClass="genes.DataFusion.solution.DataFusion_Heart"
mvn exec:java -Dexec.mainClass="genes.DataFusion.solution.DataFusion_Kidney"
mvn exec:java -Dexec.mainClass="genes.DataFusion.solution.DataFusion_Liver"
mvn exec:java -Dexec.mainClass="genes.DataFusion.solution.DataFusion_Testis"

cd UploadToAWS
dotnet run