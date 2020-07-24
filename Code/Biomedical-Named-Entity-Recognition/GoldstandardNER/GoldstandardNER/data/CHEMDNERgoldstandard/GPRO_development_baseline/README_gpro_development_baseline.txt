CEMDNER-patents GPRO subtask development set baseline predictions (Version 4th August 2015)
------------------------------------------------------------------------

For additional questions please send e-mail to: Martin Krallinger (mkrallinger@cnio.es)

This directory contains the baseline predictions for the development sets of the GPRO task
using a list lookup approach (case sensitive term lookup of the names in the training applied 
to the development set). Only GPRO mentions of type 1 were used!

1) gpro_official_dev_lookup_baseline.tsv

This file contains baseline predictions in the correct chemdner prediction format.

It consists of tab-separated columns containing:

1- Patent identifier
2- Offset string consisting in a triplet joined by the ':' character. You have to provide the text type (T: Title, A:Abstract), the start offset and the end offset.
3- The rank of the GPRO-type 1 entity returned for this document
4- A confidence score
5- The string of the GPRO-type 1 entity mention

2) gpro_official_dev_lookup_baseline.eval

This file contains the corresponding evaluation scores of the baseline predictions using the
biocreative evaluation library (bc-evaluate --INT evaluation option and the development set
gold standard annotations

bc-evaluate --INT gpro_official_dev_lookup_baseline.tsv chemdner_gpro_gold_standard_development_eval.tsv

See: http://www.biocreative.org/resources/biocreative-ii5/evaluation-library/

3) grpo_official_train_lookup_list.tsv

This file contains the list of GPRO type 1 names used for the baseline prediction
