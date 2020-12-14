import spacy
import scispacy
import en_ner_bionlp13cg_md

import csv

def getGeneNames(document):
    entityList = []
    nlp = spacy.load('en_ner_bionlp13cg_md')
    for ent in nlp(document).ents:
        if ent.label_=='GENE_OR_GENE_PRODUCT':
            entityList.append(ent.text)
    return '|'.join(entityList)

def createTitleOutputFile(inputFileName, outputFileName):
    with open('data/output/' + outputFileName, 'w', newline='') as outputFile:
        writer = csv.writer(outputFile, delimiter='\t')
        writer.writerow(['patentNumber', 'patentDate', 'patentGeneNames'])
        with open('data/input/' + inputFileName) as inputFile:
            reader = csv.reader(inputFile, delimiter='\t')
            for row in reader:
                if "2003" in row[1]: 
                    writer.writerow([row[0], row[1], getGeneNames(row[2])])
                if "2005" in row[1]: 
                    writer.writerow([row[0], row[1], getGeneNames(row[2])])
                if "2008" in row[1]: 
                    writer.writerow([row[0], row[1], getGeneNames(row[2])])
                if "2010" in row[1]: 
                    writer.writerow([row[0], row[1], getGeneNames(row[2])])
                if "2013" in row[1]: 
                    writer.writerow([row[0], row[1], getGeneNames(row[2])])
                if "2015" in row[1]: 
                    writer.writerow([row[0], row[1], getGeneNames(row[2])])

createTitleOutputFile('title.tsv', 'scispaCyTitleGene2.csv')