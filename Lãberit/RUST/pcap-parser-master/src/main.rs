use pcap_parser::*;
use pcap_parser::traits::PcapReaderIterator;
use std::fs::File;

const MAX: usize = 3;
const ENHANCEDPACKET_ID: u32 = 6;

fn main()
{
    let path = "test.pcap";
    let file = File::open(path).unwrap();
    let mut num_blocks = 0;
    let mut reader = PcapNGReader::new(65536, file).expect("PcapNGReader");
    loop {
        match reader.next() {
            Ok((offset, _block)) => {
                println!("got new block");
                num_blocks += 1;
                reader.consume(offset);
            },
            Err(PcapError::Eof) => break,
            Err(PcapError::Incomplete(_)) => {
                reader.refill().unwrap();
            },
            Err(e) => panic!("error while reading: {:?}", e),
        }
    }
    println!("num_blocks: {}", num_blocks);

    use std::fs::File;
use std::io::{BufRead, BufReader};

// const PCAPNG: &str = "/cygdrive/c/tmp/trace3.pcapng";

fn hex_str_to_num(hex_str: &str, format: &str) -> String {
    match format {
        "X" => format!("{:X}", u32::from_str_radix(hex_str, 16).unwrap()),
        "b" => format!("{:b}", u32::from_str_radix(hex_str, 16).unwrap()),
        _ => hex_str.to_string(),
    }
}

    // let file = File::open(path).unwrap();
    // let mut reader = BufReader::new(file);
    // let mut counter = MAX;

    // loop {
    //     let mut block = String::new();
    //     reader.read_line(&mut block).unwrap();

    //     println!("magic_number: {}", hex(block.magic_number()));
    //     println!("{}", block);

    //     if block.magic_number == ENHANCEDPACKET_ID {
    //         let payload_data = block.packet_payload_info[2];
    //         println!("packet_payload_info: {:?}", block.packet_payload_info);
    //         println!("packet_payload_data (hex): {}", hex_str_to_num(&payload_data, "X"));
    //         println!("packet_payload_data (bin): {}", hex_str_to_num(&payload_data, "b"));
    //     }

    //     counter -= 1;
    //     if counter == 0 {
    //         break;
    //     }
    // }
}