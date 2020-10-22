# URL
Brain_2_mart_export_brain=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Brain/Brain_2_mart_export_brain/ML_AdaBoost_StandardRecordBlocker/correspondences.csv

Cerebellum_2_mart_export_cerebellum=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Cerebellum/Cerebellum_2_mart_export_cerebellum/ML_AdaBoost_StandardRecordBlocker/correspondences.csv

Heart_2_Heart_Ensembl_NCBI_Crosswalk=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk/ML_AdaBoost_StandardRecordBlocker/correspondences.csv

Kidney_2_mart_export_kidney=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Kidney/Kidney_2_mart_export_kidney/ML_AdaBoost_StandardRecordBlocker/correspondences.csv

Liver_2_mart_export_liver=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Liver/Liver_2_mart_export_liver/ML_AdaBoost_StandardRecordBlocker/correspondences.csv

Testis_2_mart_export_testis=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Testis/Testis_2_mart_export_testis/ML_AdaBoost_StandardRecordBlocker/correspondences.csv

# Organs

Heart_2_Brain=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Heart_2_Brain/ML_AdaBoost_StandardRecordBlocker/correspondences.csv
Heart_2_Cerebellum=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Heart_2_Cerebellum/ML_AdaBoost_StandardRecordBlocker/correspondences.csv
Heart_2_Kidney=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Heart_2_Kidney/ML_AdaBoost_StandardRecordBlocker/correspondences.csv
Heart_2_Liver=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Heart_2_Liver/ML_AdaBoost_StandardRecordBlocker/correspondences.csv
Heart_2_Testis=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Heart_2_Testis/ML_AdaBoost_StandardRecordBlocker/correspondences.csv

Cerebellum_2_Brain=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Cerebellum_2_Brain/ML_AdaBoost_StandardRecordBlocker/correspondences.csv
Cerebellum_2_Kidney=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Cerebellum_2_Kidney/ML_AdaBoost_StandardRecordBlocker/correspondences.csv
Cerebellum_2_Liver=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Cerebellum_2_Liver/ML_SimpleLogistic_StandardRecordBlocker/correspondences.csv
Cerebellum_2_Testis=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Cerebellum_2_Testis/ML_SimpleLogistic_StandardRecordBlocker/correspondences.csv

Brain_2_Kidney=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Brain_2_Kidney/ML_AdaBoost_StandardRecordBlocker/correspondences.csv
Brain_2_Liver=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Brain_2_Liver/ML_AdaBoost_StandardRecordBlocker/correspondences.csv
Brain_2_Testis=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Brain_2_Testis/ML_AdaBoost_StandardRecordBlocker/correspondences.csv

Kidney_2_Liver=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Kidney_2_Liver/ML_AdaBoost_StandardRecordBlocker/correspondences.csv
Kidney_2_Testis=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Organs/Kidney_2_Testis/ML_AdaBoost_StandardRecordBlocker/correspondences.csv

# Brain
mkdir -p data/correspondences/Brain/Brain_2_mart_export_brain
wget $Brain_2_mart_export_brain -O data/correspondences/Brain/Brain_2_mart_export_brain/correspondences.csv

# Cerebellum
mkdir -p data/correspondences/Cerebellum/Cerebellum_2_mart_export_cerebellum
wget $Cerebellum_2_mart_export_cerebellum -O data/correspondences/Cerebellum/Cerebellum_2_mart_export_cerebellum/correspondences.csv

# Heart
mkdir -p data/correspondences/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk
wget $Heart_2_Heart_Ensembl_NCBI_Crosswalk -O data/correspondences/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk/correspondences.csv

mkdir -p data/correspondences/Heart/mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk
# missing

# Kidney
mkdir -p data/correspondences/Kidney/Kidney_2_mart_export_kidney
wget $Kidney_2_mart_export_kidney -O data/correspondences/Kidney/Kidney_2_mart_export_kidney/correspondences.csv

# Liver
mkdir -p data/correspondences/Liver/Liver_2_mart_export_liver
wget $Liver_2_mart_export_liver -O data/correspondences/Liver/Liver_2_mart_export_liver/correspondences.csv

# Testis
mkdir -p data/correspondences/Testis/Testis_2_mart_export_testis
wget $Testis_2_mart_export_testis -O data/correspondences/Testis/Testis_2_mart_export_testis/correspondences.csv

# Organs
mkdir -p data/correspondences/Organs/Heart_2_Brain
wget $Heart_2_Brain -O data/correspondences/Organs/Heart_2_Brain/correspondences.csv

mkdir -p data/correspondences/Organs/Heart_2_Cerebellum
wget $Heart_2_Cerebellum -O data/correspondences/Organs/Heart_2_Cerebellum/correspondences.csv

mkdir -p data/correspondences/Organs/Heart_2_Kidney
wget $Heart_2_Kidney -O data/correspondences/Organs/Heart_2_Kidney/correspondences.csv

mkdir -p data/correspondences/Organs/Heart_2_Liver
wget $Heart_2_Liver -O data/correspondences/Organs/Heart_2_Liver/correspondences.csv

mkdir -p data/correspondences/Organs/Heart_2_Testis
wget $Heart_2_Testis -O data/correspondences/Organs/Heart_2_Testis/correspondences.csv


mkdir -p data/correspondences/Organs/Cerebellum_2_Brain
wget $Cerebellum_2_Brain -O data/correspondences/Organs/Cerebellum_2_Brain/correspondences.csv

mkdir -p data/correspondences/Organs/Cerebellum_2_Kidney
wget $Cerebellum_2_Kidney -O data/correspondences/Organs/Cerebellum_2_Kidney/correspondences.csv

mkdir -p data/correspondences/Organs/Cerebellum_2_Liver
wget $Cerebellum_2_Liver -O data/correspondences/Organs/Cerebellum_2_Liver/correspondences.csv

mkdir -p data/correspondences/Organs/Cerebellum_2_Testis
wget $Cerebellum_2_Testis -O data/correspondences/Organs/Cerebellum_2_Testis/correspondences.csv


mkdir -p data/correspondences/Organs/Brain_2_Kidney
wget $Brain_2_Kidney -O data/correspondences/Organs/Brain_2_Kidney/correspondences.csv

mkdir -p data/correspondences/Organs/Brain_2_Liver
wget $Brain_2_Liver -O data/correspondences/Organs/Brain_2_Liver/correspondences.csv

mkdir -p data/correspondences/Organs/Brain_2_Testis
wget $Brain_2_Testis -O data/correspondences/Organs/Brain_2_Testis/correspondences.csv


mkdir -p data/correspondences/Organs/Kidney_2_Liver
wget $Kidney_2_Liver -O data/correspondences/Organs/Kidney_2_Liver/correspondences.csv

mkdir -p data/correspondences/Organs/Kidney_2_Testis
wget $Kidney_2_Testis -O data/correspondences/Organs/Kidney_2_Testis/correspondences.csv