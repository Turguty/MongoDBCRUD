# MongoDBCRUD

#MongoDb veritaban� kurulumu, kolleksiyon olu�turma

# 1. Mongod.exe --dbpath "Adres(C:\MongoDb\Data)"
# 2. Mongo.exe
# 3. use veritaban�ad�
# 4. Koleksiyon ekleme
db.Users(Koleksiyonad�).insertOne({ name(s�tun): "Turgut", age:"24" , password:"12345"})
# 5. Veritaban� g�r�nt�leme
db.Users.find()
# 6. Veritaban� update
db.Users.updateOne({ name: "turgut"},{ $set: {password:"passworddegisti"})
# 7. Veritaban� de�er silme
db.Users.deleteOne({name:"turgut"})
