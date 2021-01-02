from flair.data import Sentence
from flair.models import MultiTagger
from flair.tokenization import SciSpacyTokenizer

import sys
import csv

csv.field_size_limit(sys.maxsize)

tagger = MultiTagger.load("hunflair")

def getGeneNames(document):
    entityList = []
    sentence = Sentence(document, use_tokenizer=SciSpacyTokenizer())
    tagger.predict(sentence)
    for ent in sentence.get_spans():
        if 'Gene' in str(ent.labels):
            item = str(ent.text) + '|' + str(ent.start_pos) + '|' + str(ent.end_pos)
            entityList.append(item)
    return '#'.join(entityList)

def createOutputFile(inputFileName, outputFileName):
    with open(outputFileName, 'w', newline='') as outputFile:
        writer = csv.writer(outputFile, delimiter='\t')
        writer.writerow(['patentNumber', 'namedEntity', 'indexStart', 'indexEnd'])
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
                    if '|' in geneNames:
                        itemList = item.split('|')
                        writer.writerow([ row[0], itemList[0], itemList[1], itemList[2] ])
                    else:
                        writer.writerow([ row[0], "", "", "" ])


titleInputFile = 'data/input/test/test_title.txt'

titleOutputFile = 'data/output/hunFalirEvaluationTitle.csv'

createOutputFile(titleInputFile, titleOutputFile)


abstractInputFile = 'data/input/test/test_abstract.txt'

abstractOutputFile = 'data/output/hunFlairEvaluationAbstract.csv'

createOutputFile(abstractInputFile, abstractOutputFile)