from flair.data import Sentence
from flair.models import MultiTagger
from flair.tokenization import SciSpacyTokenizer

import sys
import csv

maxInt = sys.maxsize

while True:
    # decrease the maxInt value by factor 10 
    # as long as the OverflowError occurs.
    try:

        csv.field_size_limit(maxInt)
        break

    except OverflowError:
        
        maxInt = int(maxInt/10)

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

                patentNumber = row[0]

                patentText = row[1]

                geneNameMentions = getGeneNames(patentText)

                if '#' in geneNameMentions:  

                    for geneNameMentionItem in geneNameMentions.split('#'):

                        if '|' in geneNameMentionItem:

                            geneNameMentionContent = geneNameMentionItem.split('|')

                            writer.writerow([ patentNumber, geneNameMentionContent[0], geneNameMentionContent[1], geneNameMentionContent[2] ])

                else:

                    if '|' in geneNameMentions:

                        geneNameMentionContent = geneNameMentions.split('|')

                        writer.writerow([ patentNumber, geneNameMentionContent[0], geneNameMentionContent[1], geneNameMentionContent[2] ])


titleInputFile = 'data/input/test/test_title.txt'

titleOutputFile = 'data/output/hunFalirEvaluationTitle.csv'

createOutputFile(titleInputFile, titleOutputFile)


abstractInputFile = 'data/input/test/test_abstract.txt'

abstractOutputFile = 'data/output/hunFlairEvaluationAbstract.csv'

createOutputFile(abstractInputFile, abstractOutputFile)