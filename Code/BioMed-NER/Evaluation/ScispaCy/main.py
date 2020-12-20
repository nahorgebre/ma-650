import spacy
import scispacy
import en_ner_bionlp13cg_md

import sys
import csv

csv.field_size_limit(sys.maxsize)

def getGeneNames(document):
    entityList = []
    nlp = spacy.load('en_ner_bionlp13cg_md')
    for ent in nlp(document).ents:
        if ent.label_=='GENE_OR_GENE_PRODUCT':
            item = str(ent.text) + '|' + str(ent.start_char-ent.sent.start_char) + '|' + str(ent.end_char-ent.sent.start_char)
            entityList.append(item)
    return '#'.join(entityList)

def createOutputFile(inputFileName, outputFileName):
    with open(outputFileName, 'w', newline='') as outputFile:
        writer = csv.writer(outputFile, delimiter='\t')
        writer.writerow(['patentNumber', 'NamedEntity', 'indexStart', 'indexEnd'])
        with open(inputFileName) as inputFile:
            reader = csv.reader(inputFile, delimiter='\t')
            for row in reader:
                geneNames = getGeneNames(row[1])
                if '#' in geneNames:     
                    for item in geneNames.split('#'):
                        if '|' in item:
                            itemList = item.split('|')
                            writer.writerow([ row[0], itemList[0], itemList[1], itemList[2] ])
                else:
                    writer.writerow([ row[0], "", "", "" ])


titleInputFile = 'data/input/test/test_title.txt'

titleOutputFile = 'data/output/scispaCyEvaluationTitle.csv'

createOutputFile(titleInputFile, titleOutputFile)


abstractInputFile = 'data/input/test/test_abstract.txt'

abstractOutputFile = 'data/output/scispaCyEvaluationAbstract.csv'

createOutputFile(abstractInputFile, abstractOutputFile)