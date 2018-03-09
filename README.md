# MongoDBCRUD

#MongoDb veritabanı kurulumu, kolleksiyon oluşturma

# 1. Mongod.exe --dbpath "Adres(C:\MongoDb\Data)"
# 2. Mongo.exe
# 3. use veritabanıadı
# 4. Koleksiyon ekleme
db.Users(Koleksiyonadı).insertOne({ name(sütun): "Turgut", age:"24" , password:"12345"})
# 5. Veritabanı görüntüleme
db.Users.find()
# 6. Veritabanı update
db.Users.updateOne({ name: "turgut"},{ $set: {password:"passworddegisti"})
# 7. Veritabanı değer silme
db.Users.deleteOne({name:"turgut"})
