CHEMDNER-patents GPRO subtask development text data (Version 8th July 2015)
------------------------------------------------------------------------

For additional questions please send e-mail to: Martin Krallinger (mkrallinger@cnio.es)
or to the Biocreative participant mailing list: http://biocreative.sourceforge.net/mailing.html


This directory contains the development set text for the CHEMDNER-patents GPRO subtask.

1) chemdner_patents_development_text.txt: Development set

This file contains plain-text, UTF8-encoded Patent abstracts in a 
tab-separated format with the following three columns:

1- Patent identifier
2- Title of the patent
3- Abstract of the patent

In total 7000 abstracts are provided in this development set (7000 titles and 7000 abstracts).


2) chemdner_gpro_gold_standard_development.tsv

For the GPRO (gene and protein related object) task we distribute manually tagged 
patents (title and abstracts) with annotations of mentions of gene and protein related objects. 

The GPRO annotations consist of tab-separated fields containing:

1- Patent identifier
2- Type of text from which the annotation was derived (T: Title, A: Abstract)
3- Start offset
4- End offset
5- Text string of the entity mention
6- Type of GPRO entity mention (NO CLASS,NESTED MENTIONS,IDENTIFIER,SEQUENCE, FULL NAME,ABBREVIATION,FAMILY,MULTIPLE)
7- Database identifier of type 1 GPRO mentions, otherwise the tag 'GPRO_TYPE_2' if provided.


The definition of GPRO entity mentions that were annotated for the CHEMDNER-patents task was primarily concerned with capturing those types of mentions that are of practical relevance (both for end users of the extracted data as well as for the named entity recognition systems). Therefore the covered GPRO entities had to be annotated at a sufficient level of granularity to be able to determine whether the labeled mention can or can not be linked to a specific gene or gene product (represented by an entry of a biological annotation database). The annotation carried out for the CHEMDNER GPRO task was exhaustive for the types of GPRO mentions that were previously specified. This implies that mentions of other entities such as chemicals or substances should not be labeled as GPROs.
 
We distinguish two types of GPRO entity mention types:
 
(1) GPRO entity mention type 1: covering those GPRO mentions that can be normalized to a bio-entity database record. GPRO type 1 includes the following classes: NESTED MENTIONS, IDENTIFIER, FULL NAME and ABBREVIATION
 
(2) GPRO entity mention type 2: covering those GPRO mentions that in principle cannot be normalized to a unique bio-entity database record. GPRO type 2 includes the following classes: NO CLASS, SEQUENCE, FAMILY and MULTIPLE.

Important: For the GPRO task we will only use GPRO entity mentions of type 1 for evaluation purposes!

3) chemdner_gpro_gold_standard_development_eval.tsv

Gold standard evaluation format to be used for assessment with the biocreative evaluation script.

It consists of tab-separated columns containing:

1- Patent identifier
2- Offset string consisting in a triplet joined by the ':' character. You have to provide the text type (T: Title, A:Abstract), the start offset and the end offset.


Example:

CA2113023C	A:240:243
CA2113023C	A:27:36
CA2119782C	A:830:850
CA2119782C	A:855:877
CA2119782C	T:93:108
CA2120731C	A:139:144
CA2120731C	T:78:83


4) Prediction format.

The sample set provides an example prediction file to illustrate the required GPRO task prediction format.

For the GPRO task we will only request the prediction of the GPRO mention offsets following
a similar stetting as done for the BioCreative IV CHEMDNER task on PubMed abstracts or the CEMP task
of BioCreative V. Given a set of patent abstracts, the participants have to return the start and end 
indices corresponding to all the GPRO type 1 entities mentioned in this document. 

It consists of tab-separated columns containing:

1- Patent identifier
2- Offset string consisting in a triplet joined by the ':' character. You have to provide the text type (T: Title, A:Abstract), the start offset and the end offset.
3- The rank of the chemical entity returned for this document
4- A confidence score
5- The string of the GPRO entity mention (type I)


The evaluation will be done using the BioCreative Evaluation script available at:

http://www.biocreative.org/resources/biocreative-ii5/evaluation-library/

In this case the INT - article classification format option will be used.

Example command:
bc-evaluate --INT team_gpro_prediction.tsv chemdner_gpro_gold_standard_development_eval.tsv > team_gpro_prediction.eval

where --INT corresponds to the required evaluation option
team_gpro_prediction.tsv 				corresponds to the prediction file
chemdner_gpro_gold_standard_development_eval.tsv	corresponds to the evaluation file


If you have problems with the required prediction format use bc-evaluate with the flag --debug to find out what is wrong.



