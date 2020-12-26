mkdir -p data/input/PatNum
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/PatNum/US_Patents_1985_2016_313392.csv -O data/input/PatNum/US_Patents_1985_2016_313392.csv

mkdir -p data/input/CHEMDNERgoldstandard/CHEMDNER_TEST_TEXT
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/CHEMDNER_TEST_TEXT/Readme_CHEMDNER_test.pdf -O data/input/CHEMDNERgoldstandard/CHEMDNER_TEST_TEXT/Readme_CHEMDNER_test.pdf
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/CHEMDNER_TEST_TEXT/chemdner_patents_test_background_text_release.txt -O data/input/CHEMDNERgoldstandard/CHEMDNER_TEST_TEXT/chemdner_patents_test_background_text_release.txt

mkdir -p data/input/CHEMDNERgoldstandard/GPRO_development_baseline
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/GPRO_development_baseline/README_gpro_development_baseline.txt -O data/input/CHEMDNERgoldstandard/GPRO_development_baseline/README_gpro_development_baseline.txt
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/GPRO_development_baseline/gpro_official_dev_lookup_baseline.eval -O data/input/CHEMDNERgoldstandard/GPRO_development_baseline/gpro_official_dev_lookup_baseline.eval
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/GPRO_development_baseline/gpro_official_dev_lookup_baseline.tsv -O data/input/CHEMDNERgoldstandard/GPRO_development_baseline/gpro_official_dev_lookup_baseline.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/GPRO_development_baseline/grpo_official_train_lookup_list.tsv -O data/input/CHEMDNERgoldstandard/GPRO_development_baseline/grpo_official_train_lookup_list.tsv

mkdir -p data/input/CHEMDNERgoldstandard/gpro_development_set
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/gpro_development_set/README_gpro_development.txt -O data/input/CHEMDNERgoldstandard/gpro_development_set/README_gpro_development.txt
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_gpro_gold_standard_development.tsv -O data/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_gpro_gold_standard_development.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_gpro_gold_standard_development_eval.tsv -O data/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_gpro_gold_standard_development_eval.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_patents_development_text.txt -O data/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_patents_development_text.txt

mkdir -p data/input/CHEMDNERgoldstandard/gpro_training_set_v02
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/gpro_training_set_v02/README_gpro_train.txt -O data/input/CHEMDNERgoldstandard/gpro_training_set_v02/README_gpro_train.txt
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_gpro_gold_standard_train_eval_v02.tsv -O data/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_gpro_gold_standard_train_eval_v02.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_gpro_gold_standard_train_v02.tsv -O data/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_gpro_gold_standard_train_v02.tsv
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_patents_train_text.txt -O data/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_patents_train_text.txt
wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/data-preparation/input/CHEMDNERgoldstandard/gpro_training_set_v02/gpro_patent_guidelines_v1.pdf -O data/input/CHEMDNERgoldstandard/gpro_training_set_v02/gpro_patent_guidelines_v1.pdf