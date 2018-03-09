# MongoDBCRUD

#MongoDb veritabaný kurulumu, kolleksiyon oluþturma

# 1. Mongod.exe --dbpath "Adres(C:\MongoDb\Data)"
# 2. Mongo.exe
# 3. use veritabanýadý
# 4. Koleksiyon ekleme
db.Users(Koleksiyonadý).insertOne({ name(sütun): "Turgut", age:"24" , password:"12345"})
# 5. Veritabaný görüntüleme
db.Users.find()
# 6. Veritabaný update
db.Users.updateOne({ name: "turgut"},{ $set: {password:"passworddegisti"})
# 7. Veritabaný deðer silme
db.Users.deleteOne({name:"turgut"})
