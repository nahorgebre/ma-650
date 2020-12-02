#pip install scispacy
#pip install https://s3-us-west-2.amazonaws.com/ai2-s2-scispacy/releases/v0.3.0/en_ner_bionlp13cg_md-0.3.0.tar.gz
#pip install spacy==2.3.2

import spacy
import scispacy
import pandas as pd
import csv

def getPatentAbstract(data_key):
    patentAbstractList = []
    with open(data_key, "r") as f:
        reader = csv.reader(f, delimiter="\t")
        for i, line in enumerate(reader):
            if i > 0:
                patentAbstractList.append( Patent.Patent(patentNumber = line[0], patentDate = line[1], patentAbstract = line[2]) )
    return patentAbstractList

def getGeneNames(document):
    entityList = []
    nlp = spacy.load("en_ner_bionlp13cg_md")
    for ent in nlp(document).ents:
        if ent.label_=='GENE_OR_GENE_PRODUCT':
            entityList.append(ent.text)
    return '|'.join(entityList)


with open('title-output.tsv','wt') as f1:
    writer = csv.writer(f1, delimiter='\t')
    writer.writerow(['patentNumber', 'patentDate', 'genes'])
    for line in getPatentAbstract('title.tsv'):
        writer.writerow([line.patentNumber, line.patentDate, getGeneNames(line.patentAbstract)])