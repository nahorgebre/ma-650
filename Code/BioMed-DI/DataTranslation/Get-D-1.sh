# Integrate Kaessmann Datasets

mkdir -p data/input/DI1
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Brain/Brain.csv -O data/input/DI1/Brain.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Brain/mart_export_brain.txt -O data/input/DI1/mart_export_brain.txt

wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Cerebellum/Cerebellum.csv -O data/input/DI1/Cerebellum.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Cerebellum/mart_export_cerebellum.txt -O data/input/DI1/mart_export_cerebellum.txt

wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Heart/Heart.csv -O data/input/Heart/Heart.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Heart/Heart_Ensembl_NCBI_Crosswalk.txt -O data/input/DI1/Heart_Ensembl_NCBI_Crosswalk.txt
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Heart/mart_export_heart.txt -O data/input/DI1/mart_export_heart.txt

wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Kidney/Kidney.csv -O data/input/DI1/Kidney.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Kidney/mart_export_kidney.txt -O data/input/DI1/mart_export_kidney.txt

wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Liver/Liver.csv -O data/input/DI1/Liver.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Liver/mart_export_liver.txt -O data/input/DI1/mart_export_liver.txt

wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Testis/mart_export_testis.txt -O data/input/DI1/mart_export_testis.txt
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-translation/input/Testis/Testis.csv -O data/input/DI1/Testis.csv