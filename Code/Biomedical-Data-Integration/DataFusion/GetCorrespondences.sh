# Brain
mkdir -p data/correspondences/Brain/Brain_2_mart_export_brain
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-fusion/correspondences/Brain/Brain_2_mart_export_brain/correspondences.csv -O data/correspondences/Brain/Brain_2_mart_export_brain/correspondences.csv

# Cerebellum
mkdir -p data/correspondences/Cerebellum/Cerebellum_2_mart_export_cerebellum
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-fusion/correspondences/Cerebellum/Cerebellum_2_mart_export_cerebellum/correspondences.csv -O data/correspondences/Cerebellum/Cerebellum_2_mart_export_cerebellum/correspondences.csv

# Heart
mkdir -p data/correspondences/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk
wget - N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk/ML_AdaBoost_StandardRecordBlocker/correspondences.csv -O data/correspondences/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk/correspondences.csv
mkdir -p data/correspondences/Heart/Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations
mkdir -p data/correspondences/Heart/mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-fusion/correspondences/Heart/mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk/correspondences.csv -O data/correspondences/Heart/mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk/correspondences.csv

# Kidney
mkdir -p data/correspondences/Kidney/Kidney_2_mart_export_kidney
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Kidney/Kidney_2_mart_export_kidney/ML_AdaBoost_StandardRecordBlocker/correspondences.csv -O data/correspondences/Kidney/Kidney_2_mart_export_kidney/correspondences.csv

# Liver
mkdir -p data/correspondences/Liver/Liver_2_mart_export_liver
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Liver/Liver_2_mart_export_liver/ML_AdaBoost_StandardRecordBlocker/correspondences.csv -O data/correspondences/Liver/Liver_2_mart_export_liver/correspondences.csv

# Testis
mkdir -p data/correspondences/Testis/Testis_2_mart_export_testis
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/output/Testis/Testis_2_mart_export_testis/ML_AdaBoost_StandardRecordBlocker/correspondences.csv -O data/correspondences/Testis/Testis_2_mart_export_testis/correspondences.csv