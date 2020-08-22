mkdir -p data/input/Brain
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Brain/Brain.csv -O data/input/Brain/Brain.csv
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Brain/mart_export_brain.txt -O data/input/Brain/mart_export_brain.txt

mkdir -p data/input/Cerebellum
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Cerebellum/Cerebellum.csv -O data/input/Cerebellum/Cerebellum.csv
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Cerebellum/mart_export_cerebellum.txt -O data/input/Cerebellum/mart_export_cerebellum.txt

mkdir -p data/input/Gene-Disease-Associations
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Gene-Disease-Associations/all_gene_disease_pmid_associations.tsv -O data/input/Gene-Disease-Associations/all_gene_disease_pmid_associations.tsv
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Gene-Disease-Associations/readme.txt -O data/input/Gene-Disease-Associations/readme.txt

mkdir -p data/input/Gene2Pubtatorcentral
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Gene2Pubtatorcentral/gene2pubtatorcentral.tsv -O data/input/Gene2Pubtatorcentral/gene2pubtatorcentral.tsv
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Gene2Pubtatorcentral/README.txt -O data/input/Gene2Pubtatorcentral/README.txt

mkdir -p data/input/Heart
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Heart/Heart.csv -O data/input/Heart/Heart.csv
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Heart/Heart_Ensembl_NCBI_Crosswalk.txt -O data/input/Heart/Heart_Ensembl_NCBI_Crosswalk.txt
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Heart/mart_export_heart.txt -O data/input/Heart/mart_export_heart.txt

mkdir -p data/input/Kidney
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Kidney/Kidney.csv -O data/input/Kidney/Kidney.csv
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Kidney/mart_export_kidney.txt -O data/input/Kidney/mart_export_kidney.txt

mkdir -p data/input/Liver
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Liver/Liver.csv -O data/input/Liver/Liver.csv
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Liver/mart_export_liver.txt -O data/input/Liver/mart_export_liver.txt

mkdir -p data/input/Testis
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Testis/mart_export_testis.txt -O data/input/Testis/mart_export_testis.txt
wget -N https://data-translation.s3.us-east-2.amazonaws.com/input/Testis/Testis.csv -O data/input/Testis/Testis.csv