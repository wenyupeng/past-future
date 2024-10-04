const { MongoClient } = require('mongodb');

async function main() {
    // MongoDB 连接 URI
    const uri = "mongodb://localhost:27017"; // 请根据你的 MongoDB 服务器地址进行修改

    // 创建一个新的 MongoClient
    const client = new MongoClient(uri, { useNewUrlParser: true, useUnifiedTopology: true });

    try {
        // 连接到 MongoDB 服务器
        await client.connect();

        console.log("成功连接到服务器");

        // 指定数据库 如果数据库不存在，MongoDB 将创建数据库并建立连接。
        const database = client.db('runoob');

        // 使用 createCollection 方法创建集合
        const collectionName = 'exampleCollection';
        await database.createCollection(collectionName);

        const doc = { name: "Example", type: "Test" };
        const result = await collection.insertOne(doc);

        console.log(`新文档已创建，ID 为: ${result.insertedId}`);

        // 获取集合
        c//onst collection = database.collection(collectionName);

        // 创建多个新文档
        const docs = [
            { name: "Alice", age: 25, address: "Wonderland" },
            { name: "Bob", age: 30, address: "Builderland" },
            { name: "Charlie", age: 35, address: "Chocolate Factory" }
        ];

        // 插入多个文档到集合
        const result2 = await collection.insertMany(docs);

        console.log(`${result2.insertedCount} 个新文档已创建，ID 为:`);
        Object.keys(result2.insertedIds).forEach((key, index) => {
            console.log(`文档 ${index + 1}: ${result2.insertedIds[key]}`);
        });

        // 查询集合中的所有文档
        const query = {}; // 空查询对象表示查询所有文档
        const options = { projection: { _id: 0, name: 1, age: 1, address: 1 } }; // 仅选择需要的字段
        const cursor = collection.find(query, options);

        // 打印查询到的所有文档
        const allValues = await cursor.toArray();
        console.log("查询到的文档:");
        console.log(allValues);

        // 指定条件，根据 name 参数更新数据
        const filter = { name: "Alice" }; // 搜索条件
        const updateDoc = {
            $set: {
                age: 28,
                address: "New Wonderland"
            },
        };

        const updateResult = await collection.updateOne(filter, updateDoc);

        console.log(`${updateResult.matchedCount} 个文档匹配筛选条件`);
        console.log(`${updateResult.modifiedCount} 个文档已更新`);

        // 查询更新后的文档
        const updatedDocument = await collection.findOne(filter);
        console.log("更新后的文档:");
        console.log(updatedDocument);

        // 使用 sort() 方法对文档进行排序
        // 按 age 字段升序排序
        const sortedDocsAsc = await collection.find().sort({ age: 1 }).toArray();
        console.log("按 age 字段升序排序后的文档:");
        console.log(sortedDocsAsc);

        // 按 age 字段降序排序
        const sortedDocsDesc = await collection.find().sort({ age: -1 }).toArray();
        console.log("按 age 字段降序排序后的文档:");
        console.log(sortedDocsDesc);

        // 使用 limit() 方法限制查询结果的数量
        const limitedDocs = await collection.find().limit(3).toArray();
        console.log("限制查询结果为 3 条文档:");
        console.log(limitedDocs);

        // 使用 skip() 方法跳过前两个文档，返回剩余的文档
        const skippedDocs = await collection.find().skip(2).toArray();
        console.log("跳过前两个文档后的查询结果:");
        console.log(skippedDocs);

    } finally {
        // 确保在完成后关闭连接
        await client.close();
    }
}

main().catch(console.error);