## Input datasets
mkdir -p data/input
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/all_gene_disease_pmid_associations_dt.xml -O data/input/all_gene_disease_pmid_associations_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/gene2pubtatorcentral_dt.xml -O data/input/gene2pubtatorcentral_dt.xml
wget -N https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/identity-resolution/input/PubMedDate_dt.xml -O data/input/PubMedDate_dt.xml

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