# Simple-AI
Simple Conversational Artificial Intelligence for Video Games
##Concept
The basic concept is to be able to create game characters that players can talk to by typing instead of picking preset dialogue options.

The system does use preset dialogues currently, but it has the functionality to decide what inputs can be considered equivalent, and then
respond accordingly.

For example, let's say I wanted players to be able to ask my character, `"who is bob?"` and get the response, `"Bob is the king of Bobania!"`.
The players, when playing, might actually ask something like, `"can you tell me who bob is?"`, or `"I want to know who bob is."` 
In those cases, Simple-AI will determine that those phrases are equivalent to asing `"who is bob?"`, and will respond with, `"Bob is the king
of Bobania!"`, as it should.