bash GetBrainGoldstandardDatasets.sh
bash GetCerebellumGoldstandardDatasets.sh
bash GetHeartGoldstandardDatasets.sh
bash GetKidneyGoldstandardDatasets.sh
bash GetLiverGoldstandardDatasets.sh
bash GetTestisGoldstandardDatasets.sh
bash GetPublicationsGoldstandardDatasets.sh


## Organs

# Heart_2_Brain
mkdir -p data/goldstandard/Organs/Heart_2_Brain
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Brain/train.csv -O data/goldstandard/Organs/Heart_2_Brain/train.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Brain/test.csv -O data/goldstandard/Organs/Heart_2_Brain/test.csv 

# Heart_2_Cerebellum
mkdir -p data/goldstandard/Organs/Heart_2_Cerebellum
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Cerebellum/train.csv -O data/goldstandard/Organs/Heart_2_Cerebellum/train.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Cerebellum/test.csv -O data/goldstandard/Organs/Heart_2_Cerebellum/test.csv

# Heart_2_Kidney
mkdir -p data/goldstandard/Organs/Heart_2_Kidney
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Kidney/train.csv -O data/goldstandard/Organs/Heart_2_Kidney/train.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Kidney/test.csv -O data/goldstandard/Organs/Heart_2_Kidney/test.csv

# Heart_2_Liver
mkdir -p data/goldstandard/Organs/Heart_2_Liver
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Liver/train.csv -O data/goldstandard/Organs/Heart_2_Liver/train.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Liver/test.csv -O data/goldstandard/Organs/Heart_2_Liver/test.csv

# Heart_2_Testis
mkdir -p data/goldstandard/Organs/Heart_2_Testis
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Testis/train.csv -O data/goldstandard/Organs/Heart_2_Testis/train.csv
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/goldstandard/Heart_2_Testis/test.csv -O data/goldstandard/Organs/Heart_2_Testis/test.csv