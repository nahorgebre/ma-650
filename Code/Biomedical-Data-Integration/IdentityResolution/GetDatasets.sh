## Input datasets
mkdir -p data/input
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/all_gene_disease_pmid_associations_dt.xml -O data/input/all_gene_disease_pmid_associations_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/gene2pubtatorcentral_dt.xml -O data/input/gene2pubtatorcentral_dt.xml

mkdir -p data/input/Brain
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/Brain_dt.xml -O data/input/Brain/Brain_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/mart_export_brain_dt.xml -O data/input/Brain/mart_export_brain_dt.xml

mkdir -p data/input/Cerebellum
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/Cerebellum_dt.xml -O data/input/Cerebellum/Cerebellum_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/mart_export_cerebellum_dt.xml -O data/input/Cerebellum/mart_export_cerebellum_dt.xml

mkdir -p data/input/Heart
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/Heart_Ensembl_NCBI_Crosswalk_dt.xml -O data/input/Heart/Heart_Ensembl_NCBI_Crosswalk_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/Heart_dt.xml -O data/input/Heart/Heart_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/mart_export_heart_dt.xml -O data/input/Heart/mart_export_heart_dt.xml

mkdir -p data/input/Kidney
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/Kidney_dt.xml -O data/input/Kidney/Kidney_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/mart_export_kidney_dt.xml -O data/input/Kidney/mart_export_kidney_dt.xml

mkdir -p data/input/Liver
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/Liver_dt.xml -O data/input/Liver/Liver_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/mart_export_liver_dt.xml -O data/input/Liver/mart_export_liver_dt.xml

mkdir -p data/input/Testis
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/Testis_dt.xml -O data/input/Testis/Testis_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/mart_export_testis_dt.xml -O data/input/Testis/mart_export_testis_dt.xml

## Goldstandard dataset

# Brain
mkdir -p data/goldstandard/Brain/Brain_2_mart_export_brain

mkdir -p data/goldstandard/Brain/mart_export_brain_2_all_gene_disease_pmid_associations


# Cerebellum
mkdir -p data/goldstandard/Cerebellum/Cerebellum_2_mart_export_cerebellum

mkdir -p data/goldstandard/Cerebellum/mart_export_cerebellum_2_all_gene_disease_pmid_associations


# Heart
mkdir -p data/goldstandard/Heart/Heart_2_Heart_Ensembl_NCBI_Crosswalk

mkdir -p data/goldstandard/Heart/Heart_Ensembl_NCBI_Crosswalk_2_all_gene_disease_pmid_associations

mkdir -p data/goldstandard/Heart/mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk


# Kidney
mkdir -p data/goldstandard/Kidney/Kidney_2_mart_export_kidney

mkdir -p data/goldstandard/Kidney/mart_export_kidney_2_all_gene_disease_pmid_associations


# Liver
mkdir -p data/goldstandard/Liver/Liver_2_mart_export_liver

mkdir -p data/goldstandard/Liver/mart_export_liver_2_all_gene_disease_pmid_associations


# Testis
mkdir -p data/goldstandard/Testis/mart_export_testis_2_all_gene_disease_pmid_associations

mkdir -p data/goldstandard/Testis/Testis_2_mart_export_testis