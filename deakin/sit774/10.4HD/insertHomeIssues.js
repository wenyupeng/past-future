const { text } = require('express');

let sqlite3 = require('sqlite3').verbose();

let db = new sqlite3.Database('10_4HD')

let emergencyIssues = [{
    location: './img/emergency house 1.png',
    text: 'A large tree, its massive trunk splintered and roots partially uprooted,'
        + 'has fallen across a residential house. The branches have shattered windows and torn through'
        + 'the roof, causing significant structural damage. The weight of the tree has crushed one side'
        + 'of the house, leaving the walls cracked and the roof caved in. Debris is scattered across'
        + 'the yard, and the house is now partially buried under the tangled mass of leaves, branches,'
        + 'and broken wood. The scene is one of chaos, with the tree looming over the damaged home,'
        + 'emphasizing the sheer force of nature.'
},
{
    location: './img/emergency house 2.png',
    text: 'The wooden structure of the house shows clear signs of decay, with the'
        + 'once sturdy beams now soft and crumbling to the touch. The wood has darkened in color, with'
        + 'patches of mold and mildew spreading across the surface. In some areas, the wood is visibly'
        + 'warped and cracked, with sections flaking off and disintegrating into dust. The corners and'
        + 'edges of the wooden planks have begun to rot away, leaving gaps and exposing the inner'
        + 'layers. The smell of dampness and rot lingers in the air, and the house’s framework appears'
        + 'weakened, as if it could give way at any moment.'
}
]

let urgencyIssues = [{
    location: './img/urgent list1.png',
    text: 'Termites have infested the wooden structures of the house, leaving'
        + 'behind a trail of destruction. The wood appears hollowed out, with visible tunnels'
        + 'and galleries carved through beams, floorboards, and walls. The once sturdy'
        + 'framework is now brittle, crumbling at the slightest touch, and riddled with small'
        + 'holes. Piles of fine, sawdust-like material known as frass can be found around the'
        + 'baseboards, a telltale sign of their activity. In some areas, the damage is so'
        + 'severe that the wood has collapsed, compromising the integrity of the house. The'
        + 'infestation has weakened the structure, making it unsafe and requiring extensive'
        + 'repairs.'
},
{
    location: './img/urgent list2.png',
    text: 'Termites have infested the wooden structures of the house, leaving'
        + 'behind a trail of destruction. The wood appears hollowed out, with visible tunnels'
        + 'and galleries carved through beams, floorboards, and walls. The once sturdy'
        + 'framework is now brittle, crumbling at the slightest touch, and riddled with small'
        + 'holes. Piles of fine, sawdust-like material known as frass can be found around the'
        + 'baseboards, a telltale sign of their activity. In some areas, the damage is so'
        + 'severe that the wood has collapsed, compromising the integrity of the house. The'
        + 'infestation has weakened the structure, making it unsafe and requiring extensive'
        + 'repairs.'
}, {
    location: './img/urgent list2.png',
    text: 'Termites have infested the wooden structures of the house, leaving'
        + 'behind a trail of destruction. The wood appears hollowed out, with visible tunnels'
        + 'and galleries carved through beams, floorboards, and walls. The once sturdy'
        + 'framework is now brittle, crumbling at the slightest touch, and riddled with small'
        + 'holes. Piles of fine, sawdust-like material known as frass can be found around the'
        + 'baseboards, a telltale sign of their activity. In some areas, the damage is so'
        + 'severe that the wood has collapsed, compromising the integrity of the house. The'
        + 'infestation has weakened the structure, making it unsafe and requiring extensive'
        + 'repairs.'
}, {
    location: './img/urgent list2.png',
    text: 'Termites have infested the wooden structures of the house, leaving'
        + 'behind a trail of destruction. The wood appears hollowed out, with visible tunnels'
        + 'and galleries carved through beams, floorboards, and walls. The once sturdy'
        + 'framework is now brittle, crumbling at the slightest touch, and riddled with small'
        + 'holes. Piles of fine, sawdust-like material known as frass can be found around the'
        + 'baseboards, a telltale sign of their activity. In some areas, the damage is so'
        + 'severe that the wood has collapsed, compromising the integrity of the house. The'
        + 'infestation has weakened the structure, making it unsafe and requiring extensive'
        + 'repairs.'
}
]

db.serialize(function () {
    emergencyIssues.forEach(e => {
        db.run('INSERT INTO Home_Issues(type, imgurl, description) VALUES (?,?,?)', [0, e.location, e.text], function (err) {
            if (err) {
                return console.log('insert failed, err: ', err.message)
            }
            console.log('insert success')
        })
    });

    urgencyIssues.forEach(e => {
        db.run('INSERT INTO Home_Issues(type, imgurl, description) VALUES (?,?,?) ', [1, e.location, e.text], function (err) {
            if (err) {
                return console.log('insert failed, err: ', err.message)
            }
            console.log('insert success')
        })
    });
})

db.close;
