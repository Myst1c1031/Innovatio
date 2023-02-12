// Import the NFTStorage class and File constructor from the 'nft.storage' package
import { NFTStorage, File } from 'nft.storage'

// The 'mime' npm package helps us set the correct file type on our File objects
const mime = require("mime")

// The 'fs' builtin module on Node.js provides access to the file system
import fs from 'fs'

// The 'path' module provides helpers for manipulating filesystem paths
import path from 'path'

// Paste your NFT.Storage API key into the quotes:
const NFT_STORAGE_KEY = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkaWQ6ZXRocjoweEM2MjU1ODQ3NjUxMzVhNGE3MjlDMmE5NzNFM2RlOTAwQTNjM0UxNTgiLCJpc3MiOiJuZnQtc3RvcmFnZSIsImlhdCI6MTY3NjEyNjA2NTI2NCwibmFtZSI6IklNWCBoYWNrYXRob24ifQ.tsKikMPybcsqt7qDrKf6DTtJj4yYh1mmbB4pJ406VOk'

async function storeNFT(imagePath: string, name: string, description: string) {
    // load the file from disk
    const image = await fileFromPath(imagePath)

    // create a new NFTStorage client using our API key
    const nftstorage = new NFTStorage({ token: NFT_STORAGE_KEY })

    // call client.store, passing in the image & metadata
    return nftstorage.store({
        image,
        name,
        description,
    })
}
async function fileFromPath(filePath:string) {
    const content = await fs.promises.readFile(filePath)
    const type = mime.getType(filePath)
    return new File([content], path.basename(filePath), { type })
}

async function uploadNFT(imagePath: string, name: string, description: string) {
    const result = await storeNFT(imagePath, name, description)
    console.log(result)
}

//example: 
//uploadNFT("token.png","hello","world") //uploads token.png with name hello and description world
/**/